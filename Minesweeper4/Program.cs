using System;

namespace Minesweeper4
{
    class Program
    {
        static void Main(string[] args)
        {
            var grid = Grid.Unexplored(width: 10, height: 10);
            Console.Write(Renderer.RenderGrid(grid));

            var coordinates = CoordinateReader.ReadLine(Console.ReadLine());
            var newGrid = grid.Explore(coordinates);
            Console.Write(Renderer.RenderGrid(newGrid));

            Console.ReadLine();
        }
    }
}
