using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task2
{
    public class Task2
    {
        public static int FindNextBiggerNumber(int number)
        {
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
    }
}
