using NUnit.Framework;
using FizzBuzz.CountingGames;
using System.IO;

namespace FizzBuzz.Tests
{
    
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_BasicCounter()
        {
            Assert.Pass();
        }

        [Test]
        public void Test_NumberReplacerCounter()
        {
            // RENAME ALL 
            var numberReplacer = new NumberReplacerCounter();
            var input = numberReplacer.Count(100);


            // TODO More validation
            var fileContents = File.ReadAllText("../../../expectedOutput.txt");
            // Write file ouput, save and load during test           
            Assert.AreEqual(input, fileContents);
        }

        [Test]
        public void Test_NumberReplacerCounter_Expect_Failure()
        {
            // RENAME ALL 
            var numberReplacer = new NumberReplacerCounter();
            var input = numberReplacer.Count(100);


            // TODO More validation
            var fileContents = File.ReadAllText("../../../expectedOutput.txt");
            // Write file ouput, save and load during test           
            Assert.AreEqual(input, fileContents);
        }
    }
}
