﻿namespace Minesweeper4
{
    public class Coordinates
    {

        private readonly int _rowIndex;
        private readonly int _columnIndex;
        public Coordinates(int columnIndex, int rowIndex)
        {
            _rowIndex = rowIndex;
            _columnIndex = columnIndex;

        }

        public int RowIndex
        {
            get { return _rowIndex; }
        }

        public int ColumnIndex
        {
            get { return _columnIndex; }
        }

    }
}