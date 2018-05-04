﻿using System.Collections.Generic;
using System.Linq;

namespace Task4
{
    public static class AveragingMethods
    {
        public static double MedianMethod(List<double> values)
        {
            var sortedValues = values.OrderBy(x => x).ToList();

            int n = sortedValues.Count;

            if (n % 2 == 1)
            {
                return sortedValues[(n - 1) / 2];
            }

            return (sortedValues[sortedValues.Count / 2 - 1] + sortedValues[n / 2]) / 2;
        }

        public static double MeanMethod(List<double> values)
        {
            return values.Sum() / values.Count;
        }
    }
}