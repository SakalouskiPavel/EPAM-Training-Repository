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
            Assert.AreEqual(Task1.InsertNumber(11, 6, 2, 2), 15);
            Assert.AreEqual(Task1.InsertNumber(11, 9, 2, 6), 47);

        }
    }
}
