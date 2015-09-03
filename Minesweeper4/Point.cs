using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper4
{
    class Point
    {
        private bool _explored;
        private bool _isMine;
        private int _surroundingMines;

        public Point()
        {
            _explored = false;
            _isMine = false;
            _surroundingMines = 0;
        }

        public bool Explored
        {
            get { return _explored; }
  
        }

        public bool IsMine
        {
            get { return _isMine; }
        }

        public int SurroundingMines
        {
            get { return _surroundingMines; }
        }

        public void SetSurroundingMines(int surroundingMines)
        {
            _surroundingMines = surroundingMines;
        }

        public void Explore()
        {
           _explored = true;
        }

        public void SetMine()
        {
            _isMine = true;
        }



    }
}
