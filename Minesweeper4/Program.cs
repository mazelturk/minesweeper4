using System;

namespace Minesweeper4
{
    class Program
    {
        static void Main(string[] args)
        {
            var grid = new Grid(width: 10, height: 10);
            Console.Write(Renderer.RenderGrid(grid));
        }
    }
}
