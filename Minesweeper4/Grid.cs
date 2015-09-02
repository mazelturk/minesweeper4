using System.Runtime.InteropServices;

namespace Minesweeper4
{
    public class Grid
    {
        public static Grid Unexplored(int width, int height, int numMines)
        {
            var _grid = new Point[width, height];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    _grid[j, i] = new Point();
                    
                }
            }
            
            return new Grid(width, height, _grid, numMines);
   
        }

        

        private readonly int _width;
        private readonly int _height;
        private readonly int _numMines;

    

        private Point[,] _grid;

        private Grid(int width, int height, Point[,] grid, int numMines)
        {           
           
            _width = width;
            _height = height;
            _numMines = numMines;
            _grid = RandomiseMines(_grid);
        }

        private Point[,] RandomiseMines(Point[,] _grid)
        {
            for (int i = 0; i < _numMines; i++)
            {

            }
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
            _grid[coordinates.ColumnIndex, coordinates.RowIndex].Explore();

            return new Grid(Width, Height, _grid, _numMines);
        }

        public Grid InsertMine(Coordinates coordinates)
        {
            _grid[coordinates.ColumnIndex, coordinates.RowIndex].SetMine();
            return new Grid(Width, Height, _grid, _numMines);
        }

        public bool IsExplored(Coordinates coordinates)
        {
            return _grid[coordinates.ColumnIndex, coordinates.RowIndex].Explored;
        }

        public bool IsMine(Coordinates coordinates)
        {
            return _grid[coordinates.ColumnIndex, coordinates.RowIndex].IsMine;
        }

        public bool MineFound()
        {
     
            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    if (_grid[j, i].Explored && _grid[j, i].IsMine)
                    {
                        return true;
                    } 

                }
            }
            return false;

        }

        public bool FullyExplored()
        {
            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    if (!_grid[j, i].Explored && !_grid[j, i].IsMine)
                    {
                        return false;
                    }

                }
            }
            return true;
        }
    }
}
