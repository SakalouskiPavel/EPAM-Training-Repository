using System;
using System.Collections.Generic;
using NET.W._2018.Соколовский._11_12.Models;
using NUnit.Framework;

namespace NET.W._2018.Соколовский._11.Tests
{
    [TestFixture]
    public class BinarySearchTests
    {
        [TestCase(7, ExpectedResult = 4)]
        public int Find_PositiveIntNumber_Success(int arg)
        {
            var list = new List<int>() {1 ,4, 5 ,6, 7};
            return list.Find(arg);
        }

        [TestCase(7)]
        public void Find_PositiveIntNumberNullInputCollection_Exception(int arg)
        {
            List<int> list = null;
            Assert.Throws<ArgumentNullException>(() => BinarySearch.Find(list, arg));
        }

        [TestCase(null)]
        public void Find_NullElement_Exception(string arg)
        {
            List<string> list = new List<string>() { "sdfsdf", "sdggs", "werg"};
            Assert.Throws<ArgumentNullException>(() => list.Find(arg));
        }

        [TestCase(7, ExpectedResult = 4)]
        public int Find_PositiveIntNumberNullComparer_SuccessSetDefaultComparer(int arg)
        {
            var list = new List<int>() { 1, 4, 5, 6, 7 };
            return list.Find(arg, null);
        }
    }
}