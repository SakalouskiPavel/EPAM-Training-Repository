using System;
using NUnit.Framework;


namespace Task5.Tests
{
    [TestFixture]
    public class Task5Tests
    {
        [TestCase(1, 5, 0.0001, ExpectedResult = 1)]
        [TestCase(8, 3, 0.0001, ExpectedResult = 2)]
        [TestCase(0.001, 3, 0.0001, ExpectedResult = 0.1)]
        [TestCase(0.04100625, 4, 0.0001, ExpectedResult = 0.45)]
        [TestCase(8, 3, 0.0001, ExpectedResult = 2)]
        [TestCase(0.0279936, 7, 0.0001, ExpectedResult = 0.6)]
        [TestCase(0.004241979, 9, 0.00000001, ExpectedResult = 0.545)]
        public double FindNthRoot(double number, double degree, double accuracy)
        {
            return Task5.FindNthRoot(number, degree, accuracy);
        }

        [TestCase(1, -5, 0.0001)]
        public void FindNthRoot_NegativeDegree_ArgOutOfRangeExc(double number, double degree, double accuracy)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Task5.FindNthRoot(number, degree, accuracy)) ;
        }

        [TestCase(1, 5, -5)]
        public void FindNthRoot_NegativeAccuracy_ArgOutOfRangeExc(double number, double degree, double accuracy)
        {
           Assert.Throws<ArgumentOutOfRangeException>(() => Task5.FindNthRoot(number, degree, accuracy)) ;
        }
    }
}
