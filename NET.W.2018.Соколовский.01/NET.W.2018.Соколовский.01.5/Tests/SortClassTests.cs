using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NET.W._2018.Соколовский._01._5;

namespace Tests
{
    [TestClass]
    public class SortClassTests
    {
        [TestMethod]
        public void MergeSortWithPositiveNumbersTest()
        {
            int[] massive = { 5, 3, 7, 9, 1 };
            int[] sortedMassive = { 1, 3, 5, 7, 9 };
            var mergeSortResult = SortClass.MergeSort(massive);
            for (int i = 0; i < mergeSortResult.Length; i++)
            {
                Assert.AreEqual(mergeSortResult[i], sortedMassive[i]);
            }
        }

        [TestMethod]
        public void MergeSortWithNegativeNumbersTest()
        {
            int[] massive = { -23, -48, -34, -9, -4 };
            int[] sortedMassive = { -48, -34, -23, -9, -4 };
            var mergeSortResult = SortClass.MergeSort(massive);
            for (int i = 0; i < mergeSortResult.Length; i++)
            {
                Assert.AreEqual(mergeSortResult[i], sortedMassive[i]);
            }
        }

        [TestMethod]
        public void MergeSortWithIntMaxAndMinValueAndZeroTest()
        {
            int[] massive = { 0, int.MaxValue, int.MinValue };
            int[] sortedMassive = { int.MinValue, 0, int.MaxValue };
            var mergeSortResult = SortClass.MergeSort(massive);
            for (int i = 0; i < mergeSortResult.Length; i++)
            {
                Assert.AreEqual(mergeSortResult[i], sortedMassive[i]);
            }
        }

        [TestMethod]
        public void QuickSortWithPositiveNumbersTest()
        {
            int[] massive = { 5, 3, 7, 9, 1 };
            int[] sortedMassive = { 1, 3, 5, 7, 9 };
            SortClass.QuickSort(massive);
            for (int i = 0; i < massive.Length; i++)
            {
                Assert.AreEqual(massive[i], sortedMassive[i]);
            }
        }

        [TestMethod]
        public void QuickSortWithNegativeNumbersTest()
        {
            int[] massive = { -23, -48, -34, -9, -4 };
            int[] sortedMassive = { -48, -34, -23, -9, -4 };
            SortClass.QuickSort(massive);
            for (int i = 0; i < massive.Length; i++)
            {
                Assert.AreEqual(massive[i], sortedMassive[i]);
            }
        }

        [TestMethod]
        public void QuickSortWithIntMaxAndMinValueAndZeroTest()
        {
            int[] massive = { 0, int.MaxValue, int.MinValue };
            int[] sortedMassive = { int.MinValue, 0, int.MaxValue};
            SortClass.QuickSort(massive);
            for (int i = 0; i < massive.Length; i++)
            {
                Assert.AreEqual(massive[i], sortedMassive[i]);
            }
        }
    }
}
