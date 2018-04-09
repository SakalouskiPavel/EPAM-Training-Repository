using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Task1
    {
        /// <summary>
        /// Find greater common divisor by choosen method.
        /// </summary>
        /// <param name="method"></param>
        /// <param name="inputArray"></param>
        /// <returns></returns>
        public static int FindGCD(Func<int, int, int> method, params int[] inputArray)
        {
            if (ReferenceEquals(method, null))
            {
                throw new ArgumentNullException(nameof(method));
            }

            if (inputArray.Length == 0)
            {
                return 0;
            }

            int i, gcd = inputArray[0];
            for (i = 0; i < inputArray.Length - 1; i++)
            {
                gcd = method(gcd, inputArray[i + 1]);
            }
            return gcd;
            
        }

        /// <summary>
        /// Find greatest common divisor for two numbers by Evklid's algorithm.
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        /// <returns></returns>
        public static int FindEvklidGCD(int firstNumber, int secondNumber)
        {
            while (secondNumber != 0)
            {
                int temp = secondNumber;
                secondNumber = firstNumber % secondNumber;
                firstNumber = temp;
            }

            return firstNumber;
        }

        /// <summary>
        /// Find greatest common divisor for two numbers by Stein's algorithm.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int FindBinaryEvklidGCD(int a, int b)
        {
            if (a == b)
            {
                return a;
            }

            if (a == 0)
            {
                return b;
            }

            if (b == 0)
            {
                return a;
            }
            if ((~a & 1) != 0)
            {
                if ((b & 1) != 0)
                {
                    return FindBinaryEvklidGCD(a >> 1, b);
                }
                else
                {
                    return FindBinaryEvklidGCD(a >> 1, b >> 1) << 1;
                }
            }

            if ((~b & 1) != 0)
            {
                return FindBinaryEvklidGCD(a, b >> 1);
            }

            if (a > b)
            {
                return FindBinaryEvklidGCD((a - b) >> 1, b);
            }

            return FindBinaryEvklidGCD((b - a) >> 1, a);
        }
    }
}
