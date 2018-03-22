using System;

using NUnit.Framework;


namespace Task4.Tests
{
    [TestFixture]
    public class Task4Tests
    {
        [TestCase(7, new int[] { 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 }, ExpectedResult = new int[] { 7, 70, 17 })]
        [TestCase(5, new int[] { 4, 5, 8, 45, 5, 78, 7, 53, 414, 78, 63, 25 }, ExpectedResult = new int[] { 5, 45, 5, 53, 25 })]
        [TestCase(8, new int[] { -28, 43, 8, 888, 14, -78, 56, 34, 4, 82, 3, 145 }, ExpectedResult = new int[] { -28, 8, 888, -78, 82 })]
        public int[] FindDigitTest(int digit, int [] array)
        {
            return Task4.FilterDigit(digit, array);
        }

        [TestCase(-7, new int[] { 4, 5, 6 })]
        public void FindDigitTest_NegativeCriteria_ArgOutOfRangeExc(int digit, int[] array)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Task4.FilterDigit(digit, array));
        }

        [TestCase(15, new int[] { 4, 5, 6 })]
        public void FindDigitTest_MoreThan9_ArgOutOfRangeExc(int digit, int[] array)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Task4.FilterDigit(digit, array));
        }

        [TestCase(8, null)]
        public void FindDigitTest_NullInputArray_ArgOutOfRangeExc(int digit, int[] array)
        {
            Assert.Throws<ArgumentNullException>(() => Task4.FilterDigit(digit, array));
        }
    }
}
