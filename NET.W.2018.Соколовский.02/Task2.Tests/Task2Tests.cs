using System;

using NUnit.Framework;


namespace Task2.Tests
{
    [TestFixture]
    public class Task2Tests
    {
        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(144, ExpectedResult = 414)]
        [TestCase(1234321, ExpectedResult = 1241233)]
        [TestCase(1234126, ExpectedResult = 1234162)]
        [TestCase(3456432, ExpectedResult = 3462345)]
        [TestCase(10, ExpectedResult = -1)]
        [TestCase(20, ExpectedResult = -1)]
        public int FindNextBiggerNumber(int number)
        {
            return Task2.FindNextBiggerNumber(number);
        }

        [TestCase(-456)]
        public void FindNextBiggerNumber_NegativeArg_ArgumentOutOfRangeExc(int number)
        {
           Assert.Throws<ArgumentOutOfRangeException>(() => Task2.FindNextBiggerNumber(number)) ;
        }
    }
}
