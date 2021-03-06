﻿using System;
using System.Linq;
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

            return new Grid(Width, Height, _grid, _numMines);
        }

        public int CountSurroundingMines(Coordinates coordinates)
        {
            var surroundingCoordinates = Enumerable.Range(coordinates.RowIndex - 1, 3)
                .SelectMany(rowIndex =>
                    Enumerable.Range(coordinates.ColumnIndex - 1, 3)
                        .Select(columnIndex => new Coordinates(columnIndex: columnIndex, rowIndex: rowIndex)));

            return surroundingCoordinates
                .Count(surroundingCoordinate => !OutOfBounds(surroundingCoordinate) && IsMine(surroundingCoordinate));
        }

        private bool OutOfBounds(Coordinates coordinates)
        {
            return coordinates.ColumnIndex < 0 || coordinates.RowIndex < 0 || coordinates.ColumnIndex >= Width || coordinates.RowIndex >= Height;
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
