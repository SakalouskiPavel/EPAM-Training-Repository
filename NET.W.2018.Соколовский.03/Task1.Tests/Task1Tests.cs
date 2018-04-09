using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Task1.Tests
{
    [TestFixture]
    public class Task1Tests
    {
        [TestCase(2, ExpectedResult = 2)]
        [TestCase(2, 5, 6, ExpectedResult = 1)]
        [TestCase(15, 9, 33, ExpectedResult = 3)]
        [TestCase(ExpectedResult = 0)]
        [TestCase(ExpectedResult = 0)]
        [TestCase(int.MinValue + 1, int.MaxValue, ExpectedResult = int.MaxValue)]
        public int FindGCDTest(params int[] args)
        {
            return Task1.FindGCD(Task1.FindEvklidGCD, args);
        }

        [TestCase(2, ExpectedResult = 2)]
        [TestCase(2, 5, 6, ExpectedResult = 1)]
        [TestCase(15, 9, 33, ExpectedResult = 3)]
        [TestCase(ExpectedResult = 0)]
        [TestCase(ExpectedResult = 0)]
        public int FindBinaryGCDTest(params int[] args)
        {
            return Task1.FindGCD(Task1.FindBinaryEvklidGCD, args);
        }


    }
}
