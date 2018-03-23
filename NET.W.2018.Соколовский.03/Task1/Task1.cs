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
        /// Find greatest common divisor for two numbers by Evklid's algorithm.
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        /// <returns></returns>
        public static int FindGCD(int firstNumber, int secondNumber)
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
        /// Find greatest common divisor for array of numbers by Evklid's algorithm.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static int FindGCD(params int[] args)
        {
            if (args.Length == 0)
            {
                return 0;
            }

            int i, gcd = args[0];
            for (i = 0; i < args.Length - 1; i++)
            {
                gcd = FindGCD(gcd, args[i + 1]);
            }
            return gcd;
        }

        /// <summary>
        /// Find greatest common divisor for two numbers by Stein's algorithm.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int FindBinaryGCD(int a, int b)
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
                    return FindBinaryGCD(a >> 1, b);
                }
                else
                {
                    return FindBinaryGCD(a >> 1, b >> 1) << 1;
                }
            }

            if ((~b & 1) != 0)
            {
                return FindBinaryGCD(a, b >> 1);
            }

            if (a > b)
            {
                return FindBinaryGCD((a - b) >> 1, b);
            }

            return FindBinaryGCD((b - a) >> 1, a);
        }

        /// <summary>
        /// Find greatest common divisor for array of numbers by Stein's algorithm.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static int FindBinaryGCD(params int[] args)
        {
            if (args.Length == 0)
            {
                return 0;
            }

            int i, gcd = args[0];
            for (i = 0; i < args.Length - 1; i++)
            {
                gcd = FindBinaryGCD(gcd, args[i + 1]);
            }

            return gcd;
        }
    }
}
