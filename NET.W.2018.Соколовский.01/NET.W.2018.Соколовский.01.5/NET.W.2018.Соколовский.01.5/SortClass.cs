using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2018.Соколовский._01._5
{
    public class SortClass
    {
        public static int[] MergeSort(int[] massive)
        {
            if (massive.Length == 1)
            {
                return massive;
            }

            int middlePoint = massive.Length / 2;

            return Merge(MergeSort(massive.Take(middlePoint).ToArray()), MergeSort(massive.Skip(middlePoint).ToArray()));
        }

        private static int[] Merge(int[] leftMassive, int[] rightMassive)
        {
            int left = 0;
            int right = 0;
            int[] sortedMassive = new int[leftMassive.Length + rightMassive.Length];

            for (int i = 0; i < sortedMassive.Length; i++)
            {
                if (left < leftMassive.Length && right < rightMassive.Length)
                {
                    if (rightMassive[right] > leftMassive[left])
                    {
                        sortedMassive[i] = leftMassive[left++];
                    }
                    else
                    {
                        sortedMassive[i] = rightMassive[right++];
                    }
                }
                else
                {
                    if (right < rightMassive.Length)
                    {
                        sortedMassive[i] = rightMassive[right++];
                    }
                    else
                    {
                        sortedMassive[i] = leftMassive[left++];
                    }
                }
            }

            return sortedMassive;
        }

        private static int Partition(int[] massive, int left, int right)
        {
            int temp;
            int pivot = left;
            for (int i = left; i <= right; i++)
            {
                if (massive[i] < massive[right])
                {
                    temp = massive[pivot];
                    massive[pivot] = massive[i];
                    massive[i] = temp;
                    pivot += 1;
                }
            }

            temp = massive[pivot];
            massive[pivot] = massive[right];
            massive[right] = temp;
            return pivot;
        }

        private static void QuickSort(int[] massive, int left, int right)
        {
            if (left >= right)
            {
                return;
            }

            int pivot = Partition(massive, left, right);
            QuickSort(massive, left, pivot - 1);
            QuickSort(massive, pivot + 1, right);
        }

        public static void QuickSort(int[] massive)
        {
            QuickSort(massive, 0, massive.Length - 1);
        }
    }
}
