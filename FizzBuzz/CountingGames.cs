using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace FizzBuzz.CountingGames
{
    // Counting interface
    interface ICounter 
    {
       // Count between the given range and optionally output the count string
       string Count(int range, IOutput output = null);     
    }

    // Base class for all counter classes
    public abstract class CountingGame : ICounter
    {
        public abstract string Count(int range, IOutput output = null);

        // Takes an input string and passes it to a class that implements the output interface
        protected void OutputCountString(string countString, IOutput output)
        {
            // Return if no output specified
            if (output != null) output.ProcessString(countString);
        }
    }

    // Generic Counter Class
    public class BasicCounter : CountingGame
    {
        public override string Count(int range, IOutput output = null)
        {
            var sb = new StringBuilder();

            for (int i = 0; i <= range; i++)
            {
                sb.Append(i + Environment.NewLine);
            }
            // Pass the string to the given output class
            OutputCountString(sb.ToString(), output);
            return sb.ToString();
        }
    }

    // Counter that matches numbers with strings
    public class NumberReplacerCounter : CountingGame
    {
        // Pairs used when no custom int/string pairs are given
        private List<(int, string)> defaultPairs = new List<(int, string)>()
        {           
            (3, "Fizz"),
            (5, "Buzz")           
        };

        // Provide default implementation of the game e.g. "FizzBuzz"
        public override string Count(int range, IOutput output = null) => Count(defaultPairs, range, output);

        // Counts to the given range, building a string from the numbers in the sequence
        // Numbers divisible by any integers in the given pairs will be replaced by the matching string
        // If divisible by multiple pairs, a phrase is built from the matching strings in ascending order of the integers
        public string Count(List<(int, string)> pairs, int range, IOutput output = null)
        {
            var sb = new StringBuilder();

            for (int i = 1; i <= range; i++)
            {
                var matchFound = false;
                foreach (var pair in pairs.OrderBy(x => x.Item1))
                {
                    if (i % pair.Item1 == 0)
                    {
                        sb.Append(pair.Item2.ToString());
                        matchFound = true;
                    }
                }
                // If no phrases matched, add number
                if (!matchFound) sb.Append(i.ToString());
              
                sb.Append(Environment.NewLine);
            }
            // Pass the string to the given output class
            OutputCountString(sb.ToString(), output);
            return sb.ToString();
        }
    }

   // Interface that encourages the processing and output of an input string
    public interface IOutput
    {
        public void ProcessString(string stringToProcess);
    }

    // Writes input string to the console
    public class ConsoleOutput : IOutput
    {
        public void ProcessString(string stringToProcess)
        {
            Console.WriteLine(stringToProcess);
        }
    }

    // Output method that writes a string to a text file
    public class FileOutput : IOutput
    {
        // Default to current directory 
        private string filePath =  @"mynewfile.txt";

        // Provide empty constructor where no file path is specified
        public FileOutput() {}

        // Specify file path
        public FileOutput(string filePath)
        {
            this.filePath = filePath;
        }

        public void ProcessString(string stringToProcess) 
        {
            // Creates the file and writes the string to the file
            // Overwrites the file if it already exists
            File.WriteAllText(filePath, stringToProcess);
        }
    }
}
