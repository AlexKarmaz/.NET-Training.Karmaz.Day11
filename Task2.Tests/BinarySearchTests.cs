using NUnit.Framework;
using System;
using Task2.BinarySearch;

namespace Task2.Tests
{
    [TestFixture]
    public class BinarySearchTests
    {
        [TestCase(new int[] { 7, 12, 6, 9, 4, 0, 0, 3, 1 }, 4, ExpectedResult = 4)]
        [TestCase(new int[] { 7, 12, 6, 9, 4, 0, 0, 3, 1 }, 12, ExpectedResult = 8)]
        [TestCase(new int[] { 7, 12, 6, 9, 4, 0, 0, 3, 1 }, 7, ExpectedResult = 6)]
        public int Sort_Int32_PositiveTest(int[] array, int value)
        {
            Array.Sort(array);
            return array.Search<int>(value, Comparator.comparatorForInt32);
        }

        [TestCase(new string[] { "fdfs", "aaa", "abc", "fdfas"}, "abc", ExpectedResult = 1)]
        [TestCase(new string[] { "fdfs", "aaa", "abc", "fdfas" }, "aaa", ExpectedResult = 0)]
        [TestCase(new string[] { "fdfs", "aaa", "abc", "fdfas" }, "fdfas", ExpectedResult = 2)]
        public int Sort_String_PositiveTest(string[] array, string value)
        {
            Array.Sort(array);
            return array.Search<string>(value, Comparator.comparatorForString);
        }

        [TestCase(new string[] { "fdfs", "aaa", "abc", "fdfas" }, null)]
        [TestCase(null, "aaa")]
        public void Sort_ThrowsArgumentNullException(string[] array, string value)
        {
            Assert.Throws<ArgumentNullException>(() => array.Search<string>(value, Comparator.comparatorForString));
        }
    }
}
