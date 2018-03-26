using System;
using System.Linq;

using NUnit.Framework;

namespace NET.W._2018.Соколовский._05.Tests
{
    [TestFixture]
    public class BubbleSortingTests
    {
        [TestCase(new int[] { 3, 2, 1 }, new int[] { 3, 4 }, new int[] { 5, 7, 4, 12 })]
        public void BubbleSorting_ValidDataSumFuncAscendingFalse(params int[][] args)
        {
            BubbleSorting.BubbleSort(args, (x) => x.Sum(), false);
            var result = new int[][] { new int[] { 4, 5, 7, 12 }, new int[] { 3, 4 }, new int[] { 1, 2, 3 } };
            CollectionAssert.AreEqual(args, result);
        }

        [TestCase(new int[] { 3, 2, 1 }, new int[] { 3, 4 }, new int[] { 5, 7, 4, 12 })]
        public void BubbleSorting_ValidDataSumFuncAscendingTrue(params int[][] args)
        {
            BubbleSorting.BubbleSort(args, (x) => x.Sum(), true);
            var result = new int[][] { new int[] { 1, 2, 3 }, new int[] { 3, 4 }, new int[] { 4, 5, 7, 12 } };
            CollectionAssert.AreEqual(args, result);
        }

        [TestCase(new int[] { 3, 2, 1 }, new int[] { 3, 4 }, new int[] { 5, 7, 4, 12 })]
        public void BubbleSorting_ValidDataMaxFuncAscendingFalse(params int[][] args)
        {
            BubbleSorting.BubbleSort(args, (x) => x.Max(), false);
            var result = new int[][] { new int[] { 4, 5, 7, 12 }, new int[] { 3, 4 }, new int[] { 1, 2, 3 } };
            CollectionAssert.AreEqual(args, result);
        }

        [TestCase(new int[] { 3, 2, 1 }, new int[] { 3, 4 }, new int[] { 5, 7, 4, 12 })]
        public void BubbleSorting_ValidDataMaxFuncAscendingTrue(params int[][] args)
        {
            BubbleSorting.BubbleSort(args, (x) => x.Max(), true);
            var result = new int[][] { new int[] { 1, 2, 3 }, new int[] { 3, 4 }, new int[] { 4, 5, 7, 12 } };
            CollectionAssert.AreEqual(args, result);
        }

        [TestCase(new int[] { 3, 2, 1 }, new int[] { 3, 4 }, new int[] { 5, 7, 4, 12 })]
        public void BubbleSorting_ValidDataMinFuncAscendingFalse(params int[][] args)
        {
            BubbleSorting.BubbleSort(args, (x) => x.Min(), false);
            var result = new int[][] { new int[] { 4, 5, 7, 12 }, new int[] { 3, 4 }, new int[] { 1, 2, 3 } };
            CollectionAssert.AreEqual(args, result);
        }

        [TestCase(new int[] { 3, 2, 1 }, new int[] { 3, 4 }, new int[] { 5, 7, 4, 12 })]
        public void BubbleSorting_ValidDataMinFuncAscendingTrue(params int[][] args)
        {
            BubbleSorting.BubbleSort(args, (x) => x.Min(), true);
            var result = new int[][] { new int[] { 1, 2, 3 }, new int[] { 3, 4 }, new int[] { 4, 5, 7, 12 } };
            CollectionAssert.AreEqual(args, result);
        }

        [TestCase(new int[] { 3, 2, 1 }, new int[] { 3, 4 }, new int[] { 5, 7, 4, 12 })]
        public void BubbleSorting_NullArray_ArgumentNullException(params int[][] args)
        {
            Assert.Throws<ArgumentNullException>(() => BubbleSorting.BubbleSort(null, (x) => x.Min(), true));
        }

        [TestCase(new int[] { 3, 2, 1 }, new int[] { 3, 4 }, new int[] { 5, 7, 4, 12 })]
        public void BubbleSorting_NullFunction_ArgumentNullException(params int[][] args)
        {
            Assert.Throws<ArgumentNullException>(() => BubbleSorting.BubbleSort(args, null, true));
        }

        [TestCase(new int[] { 3, 2, 1 }, new int[] { 3, 4 }, null)]
        public void BubbleSorting_OneOfTheArrayNull_ArgumentNullException(params int[][] args)
        {
            Assert.Throws<ArgumentNullException>(() => BubbleSorting.BubbleSort(args, (x) => x.Min(), true));
        }
    }
}