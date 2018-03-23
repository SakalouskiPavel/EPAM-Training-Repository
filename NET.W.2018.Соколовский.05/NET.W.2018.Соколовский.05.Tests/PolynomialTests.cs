using System;
using NUnit.Framework;


namespace NET.W._2018.Соколовский._05.Tests
{
    [TestFixture]
    public class PolynomialTests
    {
        [TestCase(new double[3]{3, 4, 5}, new double[3] { 1, 2, 3 }, ExpectedResult = "8x^2 + 6x^1 + 4x^0")]
        public string AdditionOfPolinomials(double[] firstArray, double[] secondArray)
        {
            Polynomial firstPolynomial = new Polynomial(firstArray);
            Polynomial secondPolynomial = new Polynomial(secondArray);
            Polynomial resultPolynomial = firstPolynomial + secondPolynomial;
            return resultPolynomial.ToString();
        }

        [TestCase(new double[3] { 3, 4, 5 }, new double[3] { 1, 2, 3 }, ExpectedResult = "2x^2 + 2x^1 + 2x^0")]
        public string SubtractionOfPolinomials(double[] firstArray, double[] secondArray)
        {
            Polynomial firstPolynomial = new Polynomial(firstArray);
            Polynomial secondPolynomial = new Polynomial(secondArray);
            Polynomial resultPolynomial = firstPolynomial - secondPolynomial;
            return resultPolynomial.ToString();
        }

        [TestCase(new double[3] { 3, 4, 5 }, new double[3] { 1, 2, 3 }, ExpectedResult = "15x^4 + 22x^3 + 22x^2 + 10x^1 + 3x^0")]
        public string MultiplicationOfPolinomials(double[] firstArray, double[] secondArray)
        {
            Polynomial firstPolynomial = new Polynomial(firstArray);
            Polynomial secondPolynomial = new Polynomial(secondArray);
            Polynomial resultPolynomial = firstPolynomial * secondPolynomial;
            return resultPolynomial.ToString();
        }
    }
}
