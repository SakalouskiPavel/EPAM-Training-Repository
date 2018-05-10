using System;
using System.Collections.Generic;
using System.Linq;

namespace Task4
{
    public class Calculator
    {
        public Func<List<double>, double> Method;

        public Calculator()
        {
            Method = AveragingMethods.MeanMethod;
        }

        public Calculator(Func<List<double>, double> method)
        {
            Method = method;
        }

        public double CalculateAverage(List<double> values)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            if (ReferenceEquals(Method, null))
            {
                throw new ArgumentException("Invalid averaging Method value");
            }

            return Method.Invoke(values);
        }
    }
}