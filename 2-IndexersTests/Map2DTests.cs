namespace Indexers
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Map2DTests
    {
        private readonly int[] _seven = new int[] { 7, 14, 21, 28, 35, 42, 49, 56, 63, 70 };
        private IMap2D<int, int, int> _pitagoricTable;

        // Called once before each test after the constructor
        [TestInitialize]
        public void TestInitialize()
        {
            this._pitagoricTable = new Map2D<int, int, int>();
            this._pitagoricTable.Fill(
                Enumerable.Range(1, 10),
                Enumerable.Range(1, 10),
                (i, j) => i * j);
        }

        [TestMethod]
        public void FillAndIndexerTest()
        {
            for (int i = 1; i <= 10; i++)
            {
                Assert.AreEqual(i * i, this._pitagoricTable[i, i]);
            }
        }

        [TestMethod]
        public void GetRowTest()
        {
            if (!this._pitagoricTable.GetRow(7).Select(t => t.Item2).SequenceEqual(this._seven))
            {
                Assert.Fail("Wrong implementation");
            }
        }

        [TestMethod]
        public void GetColumnTest()
        {
            if (!this._pitagoricTable.GetColumn(7).Select(t => t.Item2).SequenceEqual(this._seven))
            {
                Assert.Fail("Wrong implementation");
            }
        }
    }
}
