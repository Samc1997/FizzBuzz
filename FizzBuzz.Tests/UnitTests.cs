using NUnit.Framework;
using FizzBuzz.CountingGames;
using System.IO;
using System.Collections.Generic;

namespace FizzBuzz.Tests
{
    
    public class Tests
    {
        [Test]
        public void Test_BasicCounter()
        {
            Assert.Pass();
        }

        
        // Test output of the default number replacer against
        // correct output (stored in .txt file)
        [Test]
        public void Test_NumberReplacerCounter_Defaults()
        {
            var output = new NumberReplacerCounter().Count(100);
            var fileContents = File.ReadAllText("../../../expectedOutputDefaults.txt");

            // Write file ouput, save and load during test           
            Assert.AreEqual(output, fileContents);
        }

        // Test output of the number replacer when given unorganized inputs 
        // correct output (stored in .txt file)
        [Test]
        public void Test_NumberReplacerCounter_Unorganized_Inputs()
        {
            var pairs = new List<(int, string)>()
            {
                (7, "Seven"),
                (5, "Five"),
                (6, "Six")
            };

            var input = new NumberReplacerCounter().Count(pairs, 50);
            var fileContents = File.ReadAllText("../../../expectedOutputUnorganized.txt");

            // Write file ouput, save and load during test           
            Assert.AreEqual(input, fileContents);
        }
    }
}
