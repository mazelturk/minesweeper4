namespace Minesweeper4
{
    public class Grid
    {
        public static Grid Unexplored(int width, int height)
        {
            return new Grid(width: width, height: height, grid: new int[width, height]);
        }

        private readonly int _width;
        private readonly int _height;
        private int[,] _grid;

        private Grid(int width, int height, int[,] grid)
        {           
            _grid = grid;
            _width = width;
            _height = height;
        }


        public int Width
        {
            get { return _width; }
        }

        public int Height
        {
            get { return _height; }
        }

        public Grid Explore(Coordinates coordinates)
        {
            _grid[coordinates.ColumnIndex, coordinates.RowIndex] = 1;
            return this;
        }

        public bool IsExplored(Coordinates coordinates)
        {
            return _grid[coordinates.ColumnIndex, coordinates.RowIndex] == 1;
        }

      
    }
}
