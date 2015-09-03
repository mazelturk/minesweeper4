using NUnit.Framework;

namespace Minesweeper4.Tests
{
    class GridTesting
    {
        [Test]
        public void AllCoordinatesAreUnexploredByDefault()
        {
            var grid = UnexploredGridWithNoMines(width: 3, height: 2);

            Assert.IsFalse(grid.IsExplored(columnIndex: 0, rowIndex: 0));
            Assert.IsFalse(grid.IsExplored(columnIndex: 2, rowIndex: 1));
            Assert.IsFalse(grid.IsExplored(columnIndex: 1, rowIndex: 0));
        }

        [Test]
        public void OneCoordinateExploredIsOnlyOneExplored()
        {
            Grid grid = UnexploredGridWithNoMines(width: 3, height: 2)
                .Explore(new Coordinates(2, 1));

            Assert.IsFalse(grid.IsExplored(columnIndex: 0, rowIndex: 0));
            Assert.IsFalse(grid.IsExplored(columnIndex: 2, rowIndex: 0));
            Assert.IsFalse(grid.IsExplored(columnIndex: 0, rowIndex: 1));
            Assert.IsTrue(grid.IsExplored(columnIndex: 2, rowIndex: 1));
        }

        [Test]
        public void GivenGridHasExploredPointsWhenAnotherPointIsExploredThenThosePointsAreStillExplored()
        {
            Grid grid = Grid.Unexplored(width: 3, height: 2, numMines: 0)
                .Explore(new Coordinates(2, 1))
                .Explore(new Coordinates(1, 0));

            Assert.IsTrue(grid.IsExplored(columnIndex: 2, rowIndex: 1));
        }

        [Test]
        public void OneMineInGridIsMineIsTrue()
        {
            Grid grid = Grid.Unexplored(3, 2, 0);
            grid.InsertMine(new Coordinates(2, 1));
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (j == 2 && i == 1)
                    {
                        Assert.AreEqual(true, grid.IsMine(new Coordinates(j, i)));
                    }
                    else
                    {
                        Assert.AreEqual(false, grid.IsMine(new Coordinates(j, i)));
                    }
                }
            }   


        }

        [Test]
        public void NumberOfMinesRequestedInserted()
        {
            Grid grid = Grid.Unexplored(3, 2, 2);
            grid.RandomiseMines();
            int numMines = 0;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (grid.IsMine(new Coordinates(j, i)))
                    {
                        numMines++;
                    }
                }
            }


            Assert.AreEqual(2, numMines);
        }

        private static Grid UnexploredGridWithNoMines(int width, int height)
        {
            return Grid.Unexplored(width, height, 0);
        }
    }
}
