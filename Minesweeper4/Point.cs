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

        public Point()
        {
            _explored = false;
            _isMine = false;
        }

        public bool Explored
        {
            get { return _explored; }
  
        }

        public bool IsMine
        {
            get { return _isMine; }
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
