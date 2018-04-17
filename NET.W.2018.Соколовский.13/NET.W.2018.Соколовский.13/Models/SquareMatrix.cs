using System;

namespace NET.W._2018.Соколовский._13.Models
{
    public class SquareMatrix<T> : Matrix<T>
    {
        public SquareMatrix(T[,] matrix) : base(matrix)
        {
        }

        public SquareMatrix(int size) : base(new T[size, size])
        {
        }

        protected override void CheckMatrix(T[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                throw new FormatException(nameof(matrix));
            }
        }
    }
}