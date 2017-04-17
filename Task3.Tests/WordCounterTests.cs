using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Task3.WordCounter;

namespace Task3.Tests
{
    [TestFixture]
    public class WordCounterTests
    {
        [TestCase("The", "test.txt", ExpectedResult = 21)]
        [TestCase("Clock", "test.txt", ExpectedResult = 6)]
        [TestCase("on", "test.txt", ExpectedResult = 1)]
        [TestCase("is", "test.txt", ExpectedResult = 11)]
        [TestCase("but", "test.txt", ExpectedResult = 3)]
        public int FindFrequency_PositiveTest(string word, string filePath)
        {
            var temp = FindFrequency(filePath);
            int number;
            temp.TryGetValue(word.ToUpperInvariant(), out number);
            return number;
        }
    }
}
