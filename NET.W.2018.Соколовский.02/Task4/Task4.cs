using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Task4.Properties;

namespace Task4
{
    public class Task4
    {
        /// <summary>
        /// Get array of integer numbers which contain required digit.
        /// </summary>
        /// <param name="criteria">Required digit</param>
        /// <param name="inputArray">Filtered array</param>
        /// <returns></returns>
        public static int[] FilterDigit(int criteria, int[] inputArray)
        {
            if (criteria < 0 || criteria > 9)
            {
                throw new ArgumentOutOfRangeException(Resources.WrongCriteria);
            }

            if (ReferenceEquals(inputArray, null))
            {
                throw new ArgumentNullException(Resources.NullArray);
            }

            var filtredList = new List<int>();
            foreach (int number in inputArray)
            {
                if (Regex.IsMatch(number.ToString(), criteria.ToString()))
                {
                    filtredList.Add(number);
                }
            }

            return filtredList?.ToArray();
        }
    }
}
