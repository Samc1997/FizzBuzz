using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Linq;
using System.IO;

namespace FizzBuzz.CountingGames
{

    // Counting interface
    interface ICountingGame 
    {
       // Hold Counting Logic
       string Count(int range, IOutput output = null);     
    }

    // Base class for all counter classes
    public abstract class Counter : ICountingGame
    {
        public abstract string Count(int range, IOutput output = null);

        // Takes an input string and passes it
        // to a class that implements the output interface
        protected void OutputCountString(string countString, IOutput output)
        {
            // Return if no output specified
            if (output == null) return;
            output.ProcessString(countString);
        }
    }

    // Generic Counter between the given range 
    public class BasicCounter : Counter
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

    // Counter game that replaces numbers with strings 
    public class NumberReplacerCounter : Counter
    {
        // Local internal class instead of tuple?
        private List<(int, string)> defaultPairs = new List<(int, string)>()
        {           
            (3, "Fizz"),
            (5, "Buzz")           
        };

        // Provide default implementation of the game e.g. "FizzBuzz"
        public override string Count(int range, IOutput output = null) => Count(defaultPairs, range, output);

        // Specify numbers to match with a phrase 
        // Returns string of outputs between the specified range   // pass output interface? = any class that implements ouput functionality. Default to consolelog?
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
                if (!matchFound)
                {
                    sb.Append(i.ToString());
                }
                sb.Append(Environment.NewLine);
            }
            // Pass the string to the given output class
            OutputCountString(sb.ToString(), output);

            return sb.ToString();
        }
    }

    public interface IOutput
    {
        public void ProcessString(string stringToProcess);
    }

    // Writes output to the console
    public class ConsoleOutput : IOutput
    {
        public void ProcessString(string stringToProcess)
        {
            Console.WriteLine(stringToProcess);
        }
    }

    // Output method that writes a string to a file
    public class FileOutput : IOutput
    {
        // Default to current directory 
        private readonly string defaultPath =  @"mynewfile.txt";

        public void ProcessString(string stringToProcess) => ProcessString(stringToProcess, defaultPath);

        public void ProcessString(string stringToProcess, string filePath) 
        {
            // Creates the file and writes the string to the file
            File.WriteAllText(filePath, stringToProcess);
        }
    }
}
