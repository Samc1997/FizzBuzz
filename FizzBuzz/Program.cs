using FizzBuzz.CountingGames;
using System;
using System.Collections.Generic;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            var newCounter = new NumberReplacerCounter();
            newCounter.Count(100, new ConsoleOutput());

            /*
            var pairs = new List<(int, string)>()
            {
                (7, "Seven"),
                (5, "Five"),
                (6, "Six")
            };
            newCounter.Count(pairs, 50, new FileOutput()); 
            */
        }
    }
}
