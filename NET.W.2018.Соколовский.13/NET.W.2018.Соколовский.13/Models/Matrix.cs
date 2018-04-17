using System;
using System.Security.Cryptography.X509Certificates;

namespace NET.W._2018.Соколовский._13.Models
{
    public abstract class Matrix<T>
    {
        public Matrix(T[,] matrix)
        {
            CheckMatrix(matrix);
            this._matrix = matrix;
        }

        protected T[,] _matrix { get; set; }

        public T this[int i, int j]
        {
            get
            {
                CheckIndexes(i, j);
                return this._matrix[i, j];
            }

            set
            {
                var cheked = (T[,])this._matrix.Clone();
                cheked[i, j] = value;
                CheckMatrix(cheked);
                this._matrix[i, j] = value;
            }
        }

        protected abstract void CheckMatrix(T[,] matrix);

        protected virtual void CheckIndexes(int i, int j)
        {
            if (i >= this._matrix.GetLength(0) || i < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(i));
            }

            if (j >= this._matrix.GetLength(1) || j < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(j));
            }
        }
    }
}