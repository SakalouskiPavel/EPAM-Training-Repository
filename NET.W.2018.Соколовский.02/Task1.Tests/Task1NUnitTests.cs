using NUnit.Framework;

namespace Task1.Tests
{
    [TestFixture]
    public class Task1NUnitTests
    {
        [TestCase(8, 15, 0, 0, ExpectedResult = 9)]
        [TestCase(8, 15, 3, 8, ExpectedResult = 9)]
        [TestCase(11, 6, 2, 2, ExpectedResult = 9)]
        [TestCase(11, 9, 2, 6, ExpectedResult = 9)]
        public int InsertNumberNunitTest(int numberSource, int numberIn, int i, int j)
        {
            return Task1.InsertNumber(8, 15, 0, 0);

        }
    }
}