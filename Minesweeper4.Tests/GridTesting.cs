using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Minesweeper4.Tests
{
    class GridTesting
    {
        [Test]
        public void AllCoordinatesAreUnexploredByDefault()
        {
            Grid grid = Grid.Unexplored(3, 2, 0);
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(false, grid.IsExplored(new Coordinates(i, j)));
                }
            }   
           
            
        }

        [Test]
        public void OneCoordinateExploredIsOnlyOneExplored()
        {
            Grid grid = Grid.Unexplored(3, 2);
            grid.Explore(new Coordinates(1, 2));
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (j == 2 && i == 1)
                    {
                        Assert.AreEqual(true, grid.IsExplored(new Coordinates(i, j)));
                    }
                    else
                    {
                        Assert.AreEqual(false, grid.IsExplored(new Coordinates(i, j)));
                    }
                }
            }   

        }

        [Test]
        public void TwoCoordinatesExploredOnlyOnesExplored()
        {
            Grid grid = Grid.Unexplored(3, 2, 0);
            grid.Explore(new Coordinates(1, 2)).Explore(new Coordinates(0, 1));
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (j == 2 && i == 1 || j == 1 & i == 0)
                    {
                        Assert.AreEqual(true, grid.IsExplored(new Coordinates(i, j)));
                    }
                    else
                    {
                        Assert.AreEqual(false, grid.IsExplored(new Coordinates(i, j)));
                    }
                }
            }   
            
        }

        [Test]
        public void OneMineInGridIsMineIsTrue()
        {
            Grid grid = Grid.Unexplored(3, 2, 0);
            grid.InsertMine(new Coordinates(1, 2));
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (j == 2 && i == 1)
                    {
                        Assert.AreEqual(true, grid.IsMine(new Coordinates(i, j)));
                    }
                    else
                    {
                        Assert.AreEqual(false, grid.IsMine(new Coordinates(i, j)));
                    }
                }
            }   


        }



    }
}
