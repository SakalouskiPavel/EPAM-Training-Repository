using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NET.W._2018.Соколовский._11_12.Models;
using NUnit.Framework;

namespace NET.W._2018.Соколовский._11.Tests
{
    [TestFixture]
    public class FibonacciNumbersTest
    {
        [TestCase(7)]
        public void GetNumbersTest_PositiveNumber_Success(int arg)
        {
            var expectedResult = new List<int>() { 1, 1, 2, 3, 5, 8, 13 };
            var result = FibonacciNumbers.GetNumbers(arg).ToList();
            CollectionAssert.AreEqual(expectedResult, result);
        }

        [TestCase(-1)]
        public void GetNumbersTest_NegativeNumber_Exception(int arg)
        {
            Assert.Throws<ArgumentException>(() => FibonacciNumbers.GetNumbers(arg).ToList());
        }
    }
}