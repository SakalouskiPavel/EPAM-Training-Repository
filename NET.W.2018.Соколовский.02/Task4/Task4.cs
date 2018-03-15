using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task4
{
    public class Task4
    {
        public static int[] FilterDigit(int criteria, int[] innerMassive)
        {
            var filtredList = new List<int>();
            foreach (int number in innerMassive)
            {
                if (Regex.IsMatch(number.ToString(), criteria.ToString()))
                {
                    filtredList.Add(number);
                }
            }

            if (ReferenceEquals(filtredList, null))
            {
                return null;
            }

            return filtredList.ToArray();
        }
    }
}
