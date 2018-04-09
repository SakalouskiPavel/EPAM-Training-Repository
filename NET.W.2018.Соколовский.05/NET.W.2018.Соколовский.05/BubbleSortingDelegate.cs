using System;
using NET.W._2018.Соколовский._05.Properties;

namespace NET.W._2018.Соколовский._05
{
    public class BubbleSortingDelegate
    {
        /// <summary>
        /// Sorting of jagged array by bubble sorting method.
        /// </summary>
        /// <param name="inputArrays">Sorted array.</param>
        /// <param name="function">Sorting criterion.</param>
        /// <param name="ascending">Order by ascending/descending.</param>
        public static void BubbleSort(int[][] inputArrays, Func<int[], int[], int> comparer)
        {
            if (ReferenceEquals(inputArrays, null) || inputArrays.Length == 0 || ReferenceEquals(comparer, null))
            {
                throw new ArgumentNullException(Resources.NullArgument);
            }

            foreach (var array in inputArrays)
            {
                if (ReferenceEquals(array, null) || array.Length == 0)
                {
                    throw new ArgumentNullException(Resources.NullArray);
                }
            }

            for (int i = 0; i < inputArrays.Length; i++)
            {
                for (int j = 0; j < inputArrays.Length - i - 1; j++)
                {
                    if (comparer(inputArrays[j], inputArrays[j + 1]) < 0)
                    {
                        var temp = inputArrays[j];
                        inputArrays[j] = inputArrays[j + 1];
                        inputArrays[j + 1] = temp;
                    }
                }
            }
        }
    }
}