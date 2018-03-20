using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Task2.Properties;

namespace Task2
{
    public class Task2
    {
        /// <summary>
        /// Find next bigger integer number which contains all digits from input number.
        /// </summary>
        /// <param name="number">Input number.</param>
        /// <returns></returns>
        public static int FindNextBiggerNumber(int number)
        {
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException(Resources.NegativeArg);
            }

            var numberAsCharArray = (number.ToString()).ToCharArray();
            for (var i = number + 1; i < Math.Pow(10, numberAsCharArray.Length); i++)
            {
                var currentNumberAsString = i.ToString();
                foreach (var digit in numberAsCharArray)
                {
                    if (currentNumberAsString.Contains(digit))
                    {
                        currentNumberAsString = currentNumberAsString.Remove(currentNumberAsString.IndexOf(digit), 1);
                        continue;
                    }
                    break;
                }

                if (currentNumberAsString == String.Empty)
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// Calculate run time of FindNextBiggerNumber method.
        /// </summary>
        /// <param name="number">Input number.</param>
        /// <returns></returns>
        public static long CalculateRunTime(int number)
        {
            var timer = new Stopwatch();
            timer.Start();
            FindNextBiggerNumber(number);
            timer.Stop();
            return timer.ElapsedMilliseconds;
        }
    }
}
