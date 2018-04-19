using System.Runtime.InteropServices;
using NET.W._2018.Соколовский._13.Models;
using NUnit.Framework;

namespace NET.W._2018.Соколовский._13.Tests
{
    [TestFixture]
    public class BinarySearchTreeTests
    {
        private BinarySearchTree<int> _treeTest;

        [SetUp]
        public void Init()
        {
            this._treeTest = new BinarySearchTree<int>();
            this._treeTest.Add(1);
            this._treeTest.Add(2);
            this._treeTest.Add(3);
            this._treeTest.Add(4);
            this._treeTest.Add(5);
            this._treeTest.Add(6);
        }

        [TestCase(4, ExpectedResult = 4)]
        public int FindTest_PositiveNumber_Success(int arg)
        {
            return this._treeTest.Find(4).Data;
        }
    }
}