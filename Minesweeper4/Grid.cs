using System;
using System.Runtime.InteropServices;
using System.Threading;

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
            _grid = grid;
            _width = width;
            _height = height;
            _numMines = numMines;
          
        }

        public void RandomiseMines()
        {
            for (int i = 0; i < _numMines; i++)
            {
             
                Random rnd = new Random();
                var mineX = rnd.Next(Width - 1);
                var mineY = rnd.Next(Height - 1);
                var mineCoords = new Coordinates(mineX, mineY);

                if (IsMine(mineCoords))
                {
                    i--;
                }

                InsertMine(mineCoords);
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
            if (!IsMine(coordinates))
            {
                int surroundingMines = CountSurroundingMines(coordinates);
                Console.Write(surroundingMines);
                Console.Write("\n");
                _grid[coordinates.ColumnIndex, coordinates.RowIndex].SetSurroundingMines(surroundingMines);
            }

            return new Grid(Width, Height, _grid, _numMines);
        }

        public int CountSurroundingMines(Coordinates coordinates)
        {
            int count = 0;
            for (int y = coordinates.RowIndex - 1; y <= coordinates.RowIndex + 1; y++)
            {
                for (int x = coordinates.ColumnIndex - 1; x <= coordinates.ColumnIndex + 1; x++)
                {
                    if (!OutOfBounds(x, y) && IsMine(new Coordinates(x, y)))
                    {
                        count++;
                    }
                }
            }

            return count;
            
        }

        private bool OutOfBounds(int x, int y)
        {
            return x < 0 || y < 0 || x >= Width || y >= Height;
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
