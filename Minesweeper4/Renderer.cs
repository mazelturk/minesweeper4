using System.Linq;
using System.Runtime.Serialization.Formatters;

namespace Minesweeper4
{
    public class Renderer
    {
        public static string RenderGrid(Grid grid)
        {
            var height = grid.Height;
            var width = grid.Width;
            var output = Enumerable.Range(0, height)
                .Select(rowIndex => RenderRow(width, grid, rowIndex));
     
            return string.Join("", output);
        }

        private static string RenderRow(int width, Grid grid, int rowIndex)
        {
            var columns = Enumerable.Range(0, width)
                .Select(columnIndex => !grid.IsExplored(new Coordinates(columnIndex, rowIndex))
                    ? "_"
                    : grid.IsMine(new Coordinates(columnIndex, rowIndex)) ? "*" 
                    : grid.CountSurroundingMines(new Coordinates(columnIndex, rowIndex))== 0 ? "x" 
                    : grid.CountSurroundingMines(new Coordinates(columnIndex, rowIndex)).ToString());

            return string.Join("", columns) + "\n";
        }
    }
}