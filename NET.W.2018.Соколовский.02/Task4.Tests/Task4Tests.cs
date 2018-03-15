using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task4.Tests
{
    [TestClass]
    public class Task4Tests
    {
        [TestMethod]
        public void FindDigitTest()
        {
            var expectedArray = new int[] { 7, 70, 17 };
            var innerMassive = new int[] { 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 };
            var resultMassive = Task4.FilterDigit(7, innerMassive);
            for (int i = 0; i < expectedArray.Length; i++)
            {
                Assert.AreEqual(expectedArray[i], resultMassive[i]);
            }

            expectedArray = new int[] { 5, 45, 5, 53, 25 };
            innerMassive = new int[] { 4, 5, 8, 45, 5, 78, 7, 53, 414, 78, 63, 25 };
            resultMassive = Task4.FilterDigit(5, innerMassive);
            for (int i = 0; i < expectedArray.Length; i++)
            {
                Assert.AreEqual(expectedArray[i], resultMassive[i]);
            }

            expectedArray = new int[] { -28, 8, 888, -78, 82 };
            innerMassive = new int[] { -28, 43, 8, 888, 14, -78, 56, 34, 4, 82, 3, 145 };
            resultMassive = Task4.FilterDigit(8, innerMassive);
            for (int i = 0; i < expectedArray.Length; i++)
            {
                Assert.AreEqual(expectedArray[i], resultMassive[i]);
            }
        }
    }
}
