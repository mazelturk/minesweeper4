using NUnit.Framework;

namespace Minesweeper4.Tests
{
    public class RendererTests
    {
        [Test]
        public void UnexploredGridIsRepresentedByUnderscores()
        {
            // Given
            var grid = Grid.Unexplored(width: 3, height: 2);
            // When
            var output = Renderer.RenderGrid(grid);
            // Then
            Assert.AreEqual("___\n___\n", output);
        }

        [Test]
        public void ExploredPointIsRepresentedByX()
        {
            //Given
            var grid = Grid.Unexplored(width: 3, height: 2)
                .Explore(new Coordinates(rowIndex: 1, columnIndex: 2));
            //When
            var output = Renderer.RenderGrid(grid);
            //Then
            Assert.AreEqual("___\n__x\n", output);

        }

        [Test]
        public void DiscoveredMineIsRepresentedByStar()
        {
            //Given
            var grid = Grid.Unexplored(width: 3, height: 2).InsertMine(new Coordinates(1, 2)).Explore(new Coordinates(rowIndex: 1, columnIndex: 2));
            //when 
            var output = Renderer.RenderGrid(grid);
            //Then
            Assert.AreEqual("___\n__*\n", output);
        }
    }
}
