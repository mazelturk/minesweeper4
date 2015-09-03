namespace Minesweeper4.Tests
{
    internal static class GridExtensionMethods
    {
        internal static bool IsExplored(this Grid grid, int columnIndex, int rowIndex)
        {
            return grid.IsExplored(new Coordinates(columnIndex: columnIndex, rowIndex: rowIndex));
        }
    }
}
