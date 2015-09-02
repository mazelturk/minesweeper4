using System;

namespace Minesweeper4
{
    class Program
    {
        static void Main(string[] args)
        {

            var grid = Grid.Unexplored(5, 5, 0);
            Console.Write(Renderer.RenderGrid(grid));
            bool gameWon = true;
            while (true)
            {
                var coordinates = CoordinateReader.ReadLine(Console.ReadLine());
                var newGrid = grid.Explore(coordinates);

                if (newGrid.MineFound())
                {
                    gameWon = false;
                    break;
                }

                if (newGrid.FullyExplored())
                {
                    break;
                }

                Console.Write(Renderer.RenderGrid(newGrid));

            }

            if (gameWon)
            {
                Console.Write("Congratulations!!!\n");
            }

 
        }
    }
}
