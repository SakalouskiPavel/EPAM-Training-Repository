using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task2.Tests
{
    [TestClass]
    public class Task2Tests
    {
        [TestMethod]
        public void FindNextBiggerNumber()
        {
            Assert.AreEqual(Task2.FindNextBiggerNumber(144), 414);
            Assert.AreEqual(Task2.FindNextBiggerNumber(12), 21);
            Assert.AreEqual(Task2.FindNextBiggerNumber(513), 531);
            Assert.AreEqual(Task2.FindNextBiggerNumber(10), -1);
            Assert.AreEqual(Task2.FindNextBiggerNumber(21), -1);
            Assert.AreEqual(Task2.FindNextBiggerNumber(2017), 2071);
            Assert.AreEqual(Task2.FindNextBiggerNumber(1234321), 1241233);
            Assert.AreEqual(Task2.FindNextBiggerNumber(1234126), 1234162);
            Assert.AreEqual(Task2.FindNextBiggerNumber(3456432), 3462345);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FindNextBiggerNumber_NegativeArg_ArgumentOutOfRangeExc()
        {
            Task2.FindNextBiggerNumber(-456);
        }
    }
}
