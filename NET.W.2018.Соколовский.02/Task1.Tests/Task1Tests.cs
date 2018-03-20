using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task1.Tests
{
    [TestClass]
    public class Task1Tests
    {
        [TestMethod]
        public void InsertNumberTest()
        {
            Assert.AreEqual(Task1.InsertNumber(8, 15, 0, 0), 9);
            Assert.AreEqual(Task1.InsertNumber(8, 15, 3, 8), 120);
            Assert.AreEqual(Task1.InsertNumber(11, 6, 2, 2), 11);
            Assert.AreEqual(Task1.InsertNumber(11, 9, 2, 6), 47);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertNumberTest_NegativeBorders_ArgumentOutOfRangeException()
        {
            Task1.InsertNumber(8, 15, -14, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertNumberTest_MoreThan31Borders_ArgumentOutOfRangeException()
        {
            Task1.InsertNumber(8, 15, 34, 45);
        }

    }
}
