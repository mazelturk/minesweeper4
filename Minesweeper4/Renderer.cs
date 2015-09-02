using System.Linq;

namespace Minesweeper4
{
    public class Renderer
    {
        public static string RenderGrid(Grid grid)
        {
            var height = grid.Height;
            var width = grid.Width;
            var output = Enumerable.Range(0, height)
                .Select(rowIndex => RenderRow(width));
     
            return string.Join("", output);
        }

        private static string RenderRow(int width)
        {
            var columns = Enumerable.Range(0, width)
                .Select(columnIndex => "_");
            return string.Join("", columns) + "\n";
        }
    }
}