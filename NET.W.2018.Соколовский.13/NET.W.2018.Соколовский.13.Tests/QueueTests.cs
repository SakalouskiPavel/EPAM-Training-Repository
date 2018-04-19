using System;
using NET.W._2018.Соколовский._13.Models;
using NUnit.Framework;

namespace NET.W._2018.Соколовский._13.Tests
{
    [TestFixture]
    public class QueueTests
    {
        private Queue<int> _queue;

        [SetUp]
        public void Init()
        {
            var array = new int[] { 1, 2, 3, 4, 5 };
            this._queue = new Queue<int>();
            foreach (var number in array)
            {
                this._queue.Enqueue(number);
            }
        }

        [TestCase(ExpectedResult = 5)]
        public int Dequeue_PositiveNumbers_Success()
        {
            return this._queue.Dequeue();
        }

        [TestCase(ExpectedResult = 5)]
        public int Peek_PositiveNumbers_Success()
        {
            return this._queue.Peek();
        }

        [TestCase(ExpectedResult = 4)]
        public int DoubleDequeue_PositiveNumbers_Success()
        {
            this._queue.Dequeue();
            return this._queue.Dequeue();
        }

        [TestCase(ExpectedResult = 5)]
        public int DoublePeek_PositiveNumbers_Success()
        {
            this._queue.Peek();
            return this._queue.Peek();
        }

        [TestCase(8, ExpectedResult = 8)]
        public int Enqueue_PositiveIntNumber_Success(int arg)
        {
            this._queue.Enqueue(arg);
            return this._queue.Peek();
        }
    }
}