using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task5.Tests
{
    [TestClass]
    public class Task5Tests
    {
        [TestMethod]
        public void FindNthRoot()
        {
            Assert.AreEqual(Task5.FindNthRoot(1, 5, 0.0001), 1);
            Assert.AreEqual(Task5.FindNthRoot(8, 3, 0.0001), 2);
            Assert.AreEqual(Task5.FindNthRoot(0.001, 3, 0.0001), 0.1);
            Assert.AreEqual(Task5.FindNthRoot(0.0279936, 7, 0.0001), 0.6 );
            Assert.AreEqual(Task5.FindNthRoot(0.04100625, 4, 0.0001), 0.45);
            Assert.AreEqual(Task5.FindNthRoot(0.004241979, 9, 0.00000001), 0.545);
        }
    }
}
