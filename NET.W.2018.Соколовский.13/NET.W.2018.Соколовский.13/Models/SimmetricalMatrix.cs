using System;

namespace NET.W._2018.Соколовский._13.Models
{
    public class SimmetricalMatrix<T> : SquareMatrix<T>
    {
        public SimmetricalMatrix(T[,] matrix) : base(matrix)
        {
        }

        public SimmetricalMatrix(int size) : base(size)
        {
        }

        protected override void CheckMatrix(T[,] matrix)
        {
            base.CheckMatrix(matrix);
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i != j)
                    {
                        if (!matrix[i, j].Equals(matrix[j, i]))
                        {
                            throw new FormatException(nameof(matrix));
                        }
                    }
                }
            }
        }
    }
}