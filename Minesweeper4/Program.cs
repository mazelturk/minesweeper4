using System;

namespace Minesweeper4
{
    class Program
    {
        static void Main(string[] args)
        {

            var grid = Grid.Unexplored(5, 5, 2);
            grid.RandomiseMines();
            Console.Write(Renderer.RenderGrid(grid));
            bool gameWon = true;
            while (true)
            {
                var coordinates = CoordinateReader.ReadLine(Console.ReadLine());
                var newGrid = grid.Explore(coordinates);
                Console.Write(Renderer.RenderGrid(newGrid));

                if (newGrid.MineFound())
                {
                    gameWon = false;
                    break;
                }

                if (newGrid.FullyExplored())
                {
                    break;
                }

                

            }

            if (gameWon)
            {
                Console.Write("Congratulations!!!\n");
            }
            else
            {
                Console.Write("Game Over!");
            }

            Console.ReadLine();

        }
    }
}
