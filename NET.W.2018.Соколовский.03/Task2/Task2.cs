using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task2
{
    public static class Task2
    {
        public static string ToBinaryString(this double inputNumber)
        {
            var inputNumberAsBytes = BitConverter.GetBytes(inputNumber);
            StringBuilder result = new StringBuilder();
            for (int i = inputNumberAsBytes.Length -1; i >= 0; i--)
            {
                result.Append(Convert.ToString(inputNumberAsBytes[i], 2).PadLeft(8, '0'));
            }
            return result.ToString();
        }
    }
}
