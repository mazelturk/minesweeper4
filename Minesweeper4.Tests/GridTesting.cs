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
        public void CanExploreCoordinates()
        {
            //given
            Grid grid = new Grid(3, 2);
            //when
            grid.Explore(new Coordinates(1, 2));
            //then
            Assert.AreEqual(grid.Point(new Coordinates(1, 2)), 1);
        } 
        
        [Test]
        public void IsExploredWorks()
        {
            //given
            Grid grid = new Grid(3, 2);
            //when
            var coordinates = new Coordinates(1, 2);
            grid.Explore(coordinates);
            //then
            Assert.AreEqual(true, grid.IsExplored(coordinates));
        }



    }
}
