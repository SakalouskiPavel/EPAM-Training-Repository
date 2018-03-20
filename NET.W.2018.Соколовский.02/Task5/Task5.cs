using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.Properties;

namespace Task5
{
    public class Task5
    {
        /// <summary>
        /// Find the root by the method of newton.
        /// </summary>
        /// <param name="number">Input number.</param>
        /// <param name="degree">Target degree.</param>
        /// <param name="accuracy">Required accuracy</param>
        /// <returns></returns>
        public static double FindNthRoot(double number, double degree, double accuracy = 0.0001)
        {
            if (degree < 0)
            {
                throw new ArgumentOutOfRangeException(Resources.NegativeDegree);
            }

            if (accuracy < 0)
            {
                throw new ArgumentOutOfRangeException(Resources.NegativeAccuracy);
            }

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
