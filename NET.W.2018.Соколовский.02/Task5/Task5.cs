using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    public class Task5
    {
        public static double FindNthRoot(double number, double degree, double accuracy = 0.0001)
        {
            double x0 = number / degree;
            double x1 = (1 / degree) * ((degree - 1) * x0 + number / Math.Pow(x0, degree - 1));

            while (Math.Abs(x1 - x0) > accuracy)
            {
                x0 = x1;
                x1 = (1 / degree) * ((degree - 1) * x0 + number / Math.Pow(x0, degree - 1));
            }

            return Math.Round(x1,3);
        }
    }
}
