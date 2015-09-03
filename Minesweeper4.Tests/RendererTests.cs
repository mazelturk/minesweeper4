using NUnit.Framework;

namespace Minesweeper4.Tests
{
    public class RendererTests
    {
        [Test]
        public void UnexploredGridIsRepresentedByUnderscores()
        {
            // Given
            var grid = Grid.Unexplored(3, 2, 0);
            // When
            var output = Renderer.RenderGrid(grid);
            // Then
            Assert.AreEqual("___\n___\n", output);
        }

        [Test]
        public void ExploredPointIsRepresentedByX()
        {
            //Given
            var grid = Grid.Unexplored(3, 2, 0)
                .Explore(new Coordinates( 2,  1));
            //When
            var output = Renderer.RenderGrid(grid);
            //Then
            Assert.AreEqual("___\n__x\n", output);

        }

        [Test]
        public void DiscoveredMineIsRepresentedByStar()
        {
            //Given
            var grid = Grid.Unexplored(3, 2, 0).InsertMine(new Coordinates(2, 1)).Explore(new Coordinates( 2,  1));
            //when 
            var output = Renderer.RenderGrid(grid);
            //Then
            Assert.AreEqual("___\n__*\n", output);
        }
    }
}
