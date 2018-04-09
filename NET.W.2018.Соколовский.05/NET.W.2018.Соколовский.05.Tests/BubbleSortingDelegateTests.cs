using System;
using NET.W._2018.Соколовский._05.Comparers;
using NUnit.Framework;

namespace NET.W._2018.Соколовский._05.Tests
{
    [TestFixture]
    public class BubbleSortingDelegateTests
    {
        [TestCase(new int[] { 3, 2, 1 }, new int[] { 3, 4 }, new int[] { 5, 7, 4, 12 })]
        public void BubbleSorting_ValidDataSumFuncAscendingFalse(params int[][] args)
        {
            BubbleSortingDelegate.BubbleSort(args, new SumComparer().Compare);
            var result = new int[][] { new int[] { 5, 7, 4, 12 }, new int[] { 3, 4 }, new int[] { 3, 2, 1 } };
            CollectionAssert.AreEqual(args, result);
        }

        [TestCase(new int[] { 3, 2, 1 }, new int[] { 3, 4 }, new int[] { 5, 7, 4, 12 })]
        public void BubbleSorting_ValidDataSumFuncAscendingTrue(params int[][] args)
        {
            BubbleSortingDelegate.BubbleSort(args, new SumComparer(true).Compare);
            var result = new int[][] { new int[] { 3, 2, 1 }, new int[] { 3, 4 }, new int[] { 5, 7, 4, 12 } };
            CollectionAssert.AreEqual(args, result);
        }

        [TestCase(new int[] { 3, 2, 1 }, new int[] { 3, 4 }, new int[] { 5, 7, 4, 12 })]
        public void BubbleSorting_ValidDataMaxFuncAscendingFalse(params int[][] args)
        {
            BubbleSortingDelegate.BubbleSort(args, new MaxComparer().Compare);
            var result = new int[][] { new int[] { 5, 7, 4, 12 }, new int[] { 3, 4 }, new int[] { 3, 2, 1 } };
            CollectionAssert.AreEqual(args, result);
        }

        [TestCase(new int[] { 3, 2, 1 }, new int[] { 3, 4 }, new int[] { 5, 7, 4, 12 })]
        public void BubbleSorting_ValidDataMaxFuncAscendingTrue(params int[][] args)
        {
            BubbleSortingDelegate.BubbleSort(args, new MaxComparer(true).Compare);
            var result = new int[][] { new int[] { 3, 2, 1 }, new int[] { 3, 4 }, new int[] { 5, 7, 4, 12 } };
            CollectionAssert.AreEqual(args, result);
        }

        [TestCase(new int[] { 3, 2, 1 }, new int[] { 3, 4 }, new int[] { 5, 7, 4, 12 })]
        public void BubbleSorting_ValidDataMinFuncAscendingFalse(params int[][] args)
        {
            BubbleSortingDelegate.BubbleSort(args, new MinComparer().Compare);
            var result = new int[][] { new int[] { 5, 7, 4, 12 }, new int[] { 3, 4 }, new int[] { 3, 2, 1 } };
            CollectionAssert.AreEqual(args, result);
        }

        [TestCase(new int[] { 3, 2, 1 }, new int[] { 3, 4 }, new int[] { 5, 7, 4, 12 })]
        public void BubbleSorting_ValidDataMinFuncAscendingTrue(params int[][] args)
        {
            BubbleSortingDelegate.BubbleSort(args, new MinComparer(true).Compare);
            var result = new int[][] { new int[] { 3, 2, 1 }, new int[] { 3, 4 }, new int[] { 5, 7, 4, 12 } };
            CollectionAssert.AreEqual(args, result);
        }

        [TestCase(new int[] { 3, 2, 1 }, new int[] { 3, 4 }, new int[] { 5, 7, 4, 12 })]
        public void BubbleSorting_NullArray_ArgumentNullException(params int[][] args)
        {
            Assert.Throws<ArgumentNullException>(() => BubbleSortingDelegate.BubbleSort(null, new MinComparer(true).Compare));
        }

        [TestCase(new int[] { 3, 2, 1 }, new int[] { 3, 4 }, new int[] { 5, 7, 4, 12 })]
        public void BubbleSorting_NullFunction_ArgumentNullException(params int[][] args)
        {
            Assert.Throws<ArgumentNullException>(() => BubbleSortingDelegate.BubbleSort(args, null));
        }

        [TestCase(new int[] { 3, 2, 1 }, new int[] { 3, 4 }, null)]
        public void BubbleSorting_OneOfTheArrayNull_ArgumentNullException(params int[][] args)
        {
            Assert.Throws<ArgumentNullException>(() => BubbleSortingDelegate.BubbleSort(args, new MinComparer(true).Compare));
        }
    }
}