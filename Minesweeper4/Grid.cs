namespace Minesweeper4
{
    public class Grid
    {
        private readonly int _width;
        private readonly int _height;
        private int[,] _grid;

        public Grid(int width, int height)
        {           
            _grid = new int[width,height];
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

        public int Point(Coordinates coordinates)
        {
            return _grid[coordinates.ColumnIndex, coordinates.RowIndex];
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
