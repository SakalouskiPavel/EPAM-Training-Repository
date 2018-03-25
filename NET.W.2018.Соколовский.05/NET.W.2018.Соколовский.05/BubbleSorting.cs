using System;

namespace NET.W._2018.Соколовский._05
{
    public static class BubbleSorting
    {
        public static void BubbleSort(int[][] inputArrays, Func<int[], int> function, bool ascending = true)
        {
            if (ReferenceEquals(inputArrays, null) || inputArrays.Length == 0)
            {
                throw new ArgumentNullException();
            }

            foreach (var array in inputArrays)
            {
                if (ReferenceEquals(array, null) || array.Length == 0)
                {
                    throw new ArgumentNullException();
                }
            }

            for (int i = 0; i < inputArrays.Length; i++)
            {
                for (int j = 0; j < inputArrays.Length - i - 1; j++)
                {
                    if (ascending)
                    {
                        if (function(inputArrays[j]) > function(inputArrays[j + 1]))
                        {
                            int[] temp = inputArrays[j];
                            inputArrays[j] = inputArrays[j + 1];
                            inputArrays[j + 1] = temp;
                        }
                    }
                    else
                    {
                        if (function(inputArrays[j]) < function(inputArrays[j + 1]))
                        {
                            int[] temp = inputArrays[j];
                            inputArrays[j] = inputArrays[j + 1];
                            inputArrays[j + 1] = temp;
                        }
                    }
                }
            }

            foreach (var array in inputArrays)
            {
                BubbleSort(array);
            }
        }

        private static void BubbleSort(int[] inputArray)
        {
            for (int i = 0; i < inputArray.Length; i++)
            {
                for (int j = 0; j < inputArray.Length - i - 1; j++)
                {
                    if (inputArray[j] > inputArray[j + 1])
                    {
                        int temp = inputArray[j];
                        inputArray[j] = inputArray[j + 1];
                        inputArray[j + 1] = temp;
                    }
                }
            }
        }
    }
}