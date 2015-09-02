namespace Minesweeper4
{
    public class Renderer
    {
        public static string RenderGrid(Grid grid)
        {
            var height = grid.Height;
            var width = grid.Width;
            var output = "";
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    output += "_";
                }
                output += "\n";
            }

            return output;
        }
    }
}