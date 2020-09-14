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
            // Without an output
            var test = newCounter.Count(100);
            newCounter.Count(100, new FileOutput());
        }
    }
}
