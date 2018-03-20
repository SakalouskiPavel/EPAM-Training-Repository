using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NET.W._2018.Соколовский._01._5.Properties;

namespace NET.W._2018.Соколовский._01._5
{
    public class SortClass
    {
        /// <summary>
        /// Split input array in half.
        /// </summary>
        /// <param name="array">Input array.</param>
        /// <returns></returns>
        public static int[] MergeSort(int[] array)
        {
            if (ReferenceEquals(array, null))
            {
                throw new ArgumentNullException(Resources.NullArray);
            }

            if (array.Length == 1)
            {
                return array;
            }

            int middlePoint = array.Length / 2;

            return Merge(MergeSort(array.Take(middlePoint).ToArray()), MergeSort(array.Skip(middlePoint).ToArray()));
        }

        /// <summary>
        /// Sort divided arrays.
        /// </summary>
        /// <param name="leftArray"></param>
        /// <param name="rightArray"></param>
        /// <returns></returns>
        private static int[] Merge(int[] leftArray, int[] rightArray)
        {
            int left = 0;
            int right = 0;
            int[] sortedMassive = new int[leftArray.Length + rightArray.Length];

            for (int i = 0; i < sortedMassive.Length; i++)
            {
                if (left < leftArray.Length && right < rightArray.Length)
                {
                    if (rightArray[right] > leftArray[left])
                    {
                        sortedMassive[i] = leftArray[left++];
                    }
                    else
                    {
                        sortedMassive[i] = rightArray[right++];
                    }
                }
                else
                {
                    if (right < rightArray.Length)
                    {
                        sortedMassive[i] = rightArray[right++];
                    }
                    else
                    {
                        sortedMassive[i] = leftArray[left++];
                    }
                }
            }

            return sortedMassive;
        }

        /// <summary>
        /// Gets sorting pivot.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        private static int Partition(int[] array, int left, int right)
        {
            int temp;
            int pivot = left;
            for (int i = left; i <= right; i++)
            {
                if (array[i] < array[right])
                {
                    temp = array[pivot];
                    array[pivot] = array[i];
                    array[i] = temp;
                    pivot += 1;
                }
            }

            temp = array[pivot];
            array[pivot] = array[right];
            array[right] = temp;
            return pivot;
        }

        /// <summary>
        /// Sort input array by quick sorting method.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        private static void QuickSort(int[] array, int left, int right)
        {
            if (left >= right)
            {
                return;
            }

            int pivot = Partition(array, left, right);
            QuickSort(array, left, pivot - 1);
            QuickSort(array, pivot + 1, right);
        }

        /// <summary>
        /// Sort input array by quick sorting method.
        /// </summary>
        /// <param name="array"></param>
        public static void QuickSort(int[] array)
        {
            if (ReferenceEquals(array, null))
            {
                throw new ArgumentNullException(Resources.NullArray);
            }

            QuickSort(array, 0, array.Length - 1);
        }
    }
}
