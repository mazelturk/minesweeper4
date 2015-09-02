using NUnit.Framework;

namespace Minesweeper4.Tests
{
    public class RendererTests
    {
        [Test]
        public void UnexploredGridIsRepresentedByUnderscores()
        {
            // Given
            var grid = new Grid(width: 3, height: 2);
            // When
            var output = Renderer.RenderGrid(grid);
            // Then
            Assert.AreEqual("___\n___\n", output);
        }
    }
}
