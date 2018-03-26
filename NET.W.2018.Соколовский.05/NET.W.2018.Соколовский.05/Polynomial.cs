using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using NET.W._2018.Соколовский._05.Properties;

namespace NET.W._2018.Соколовский._05
{
    public class Polynomial
    {
        private double[] _coefficients;

        public Polynomial(double[] coefficients)
        {
            this._coefficients = coefficients;
        }


        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null) || !(obj is Polynomial))
            {
                return false;
            }

            return this == obj as Polynomial;
        }

        public override int GetHashCode()
        {
            return this._coefficients.GetHashCode();
        }

        public override string ToString()
        {
            if (ReferenceEquals(this._coefficients, null))
            {
                throw new NullReferenceException(Resources.NullCoeficients);
            }

            StringBuilder result = new StringBuilder();
            for (int i = this._coefficients.Length - 1; i >= 0; i--)
            {
                result.Append($"{this._coefficients[i]}x^{i}");
                if (i > 0)
                {
                    result.Append(" + ");
                }
            }
            return result.ToString();
        }

        public static Polynomial operator +(Polynomial firstOperand, Polynomial secondOperand)
        {
            if (ReferenceEquals(firstOperand, null) || ReferenceEquals(secondOperand, null))
            {
                throw new ArgumentNullException(Resources.NullOperand);
            }

            int greaterLength = firstOperand._coefficients.Length > secondOperand._coefficients.Length ?
                firstOperand._coefficients.Length : secondOperand._coefficients.Length;
            double[] result = new double[greaterLength];
            for (int i = 0; i < greaterLength; i++)
            {
                if (firstOperand._coefficients.Length - 1 < i)
                {
                    result[i] = secondOperand._coefficients[i];
                }
                else if (secondOperand._coefficients.Length - 1 < i)
                {
                    result[i] = firstOperand._coefficients[i];
                }
                else
                {
                    result[i] = firstOperand._coefficients[i] + secondOperand._coefficients[i];
                }
            }

            return new Polynomial(result);
        }

        public static Polynomial operator -(Polynomial firstOperand, Polynomial secondOperand)
        {
            if (ReferenceEquals(firstOperand, null) || ReferenceEquals(secondOperand, null))
            {
                throw new ArgumentNullException(Resources.NullOperand);
            }

            int greaterLength = firstOperand._coefficients.Length > secondOperand._coefficients.Length ?
                firstOperand._coefficients.Length : secondOperand._coefficients.Length;
            double[] result = new double[greaterLength];
            for (int i = 0; i < greaterLength; i++)
            {
                if (firstOperand._coefficients.Length - 1 < i)
                {
                    result[i] = secondOperand._coefficients[i];
                }
                else if (secondOperand._coefficients.Length - 1 < i)
                {
                    result[i] = firstOperand._coefficients[i];
                }
                else
                {
                    result[i] = firstOperand._coefficients[i] - secondOperand._coefficients[i];
                }
            }

            return new Polynomial(result);
        }

        public static Polynomial operator *(Polynomial firstOperand, Polynomial secondOperand)
        {
            if (ReferenceEquals(firstOperand, null) || ReferenceEquals(secondOperand, null))
            {
                throw new ArgumentNullException(Resources.NullOperand);
            }

            double[] result = new double[firstOperand._coefficients.Length + secondOperand._coefficients.Length - 1];
            for (int i = 0; i < firstOperand._coefficients.Length; i++)
            {
                for (int j = 0; j < secondOperand._coefficients.Length; j++)
                {
                    result[i + j] += secondOperand._coefficients[j] * firstOperand._coefficients[i];
                }
            }
            return new Polynomial(result);
        }

        public static bool operator ==(Polynomial firstOperand, Polynomial secondOperand)
        {
            if (ReferenceEquals(firstOperand, null) || ReferenceEquals(secondOperand, null) ||
                ReferenceEquals(firstOperand._coefficients, null) || ReferenceEquals(secondOperand._coefficients, null))
            {
                throw new ArgumentNullException(Resources.NullOperand);
            }

            if (firstOperand._coefficients.Length != secondOperand._coefficients.Length)
            {
                return false;
            }

            for (int i = 0; i < firstOperand._coefficients.Length; i++)
            {
                if (firstOperand._coefficients[i] != secondOperand._coefficients[i])
                {
                    return false;
                }
            }
            return true;
        }

        public static bool operator !=(Polynomial firstOperand, Polynomial secondOperand)
        {
            return !(firstOperand == secondOperand);
        }
    }
}
