using System;
using NET.W._2018.Соколовский._13.Models;
using NUnit.Framework;

namespace NET.W._2018.Соколовский._13.Tests
{
    [TestFixture]
    public class MatrixTests
    {
        private int[,] _rectangleMatrix;

        private int[,] _squareMatrix;

        private int[,] _simmetricalMatrix;

        private int[,] _diagonalMatrix;

        [SetUp]
        public void Init()
        {
            _rectangleMatrix = new int[4, 5]
            {
                { 1, 2, 3, 4, 5 },
                { 2, 3, 4, 5, 6 },
                { 3, 4, 5, 6, 7 },
                { 4, 5, 6, 7, 8 }
            };

            _squareMatrix = new int[4, 4]
            {
                { 2, 3, 4, 5 },
                { 2, 4, 5, 6 },
                { 3, 4, 6, 7 },
                { 4, 5, 6, 7 }
            };

            this._simmetricalMatrix = new int[4, 4]
            {
                { 1, 2, 3, 4 },
                { 2, 3, 4, 5 },
                { 3, 4, 5, 6 },
                { 4, 5, 6, 7 }
            };

            this._diagonalMatrix = new int[4, 4]
            {
                { 1, 0, 0, 0 },
                { 0, 2, 0, 0 },
                { 0, 0, 5, 0 },
                { 0, 0, 0, 7 }
            };
        }

        [Test]
        public void NewSquareMatrix_SquareMatrix_Success()
        {
            SquareMatrix<int> result = new SquareMatrix<int>(this._squareMatrix);
            CollectionAssert.AreEqual(this._squareMatrix, result.ToArray());
        }

        [Test]
        public void NewSquareMatrix_RectangleMatrix_Exception()
        {
            Assert.Throws<FormatException>(() => new SquareMatrix<int>(this._rectangleMatrix));
        }

        [Test]
        public void NewSimmetricalMatrix_SimmetricalMatrix_Success()
        {
            SimmetricalMatrix<int> result = new SimmetricalMatrix<int>(this._simmetricalMatrix);
            CollectionAssert.AreEqual(this._simmetricalMatrix, result.ToArray());
        }

        [Test]
        public void NewSimmetricalMatrix_RectangleMatrix_Exception()
        {
            Assert.Throws<FormatException>(() => new SimmetricalMatrix<int>(this._rectangleMatrix));
        }

        [Test]
        public void NewSimmetricalMatrix_SquareMatrix_Exception()
        {
            Assert.Throws<FormatException>(() => new SimmetricalMatrix<int>(this._squareMatrix));
        }

        [Test]
        public void NewDiagonalMatrix_DiagonalMatrix_Success()
        {
            DiagonalMatrix<int> result = new DiagonalMatrix<int>(this._diagonalMatrix);
            CollectionAssert.AreEqual(this._diagonalMatrix, result.ToArray());
        }

        [Test]
        public void NewDiagonalMatrix_RectangleMatrix_Exception()
        {
            Assert.Throws<FormatException>(() => new DiagonalMatrix<int>(this._rectangleMatrix));
        }

        [Test]
        public void NewDiagonalMatrix_SquareMatrix_Exception()
        {
            Assert.Throws<FormatException>(() => new DiagonalMatrix<int>(this._squareMatrix));
        }

        [Test]
        public void NewDiagonalMatrix_SimmetricalMatrix_Exception()
        {
            Assert.Throws<FormatException>(() => new DiagonalMatrix<int>(this._simmetricalMatrix));
        }
    }
}