using System;

namespace Minesweeper4
{
    internal class CoordinateReader
    {
        public static Coordinates ReadLine(string readLine)
        {
            string[] coordinates = readLine.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries);
            int x;
            int y;
            Int32.TryParse(coordinates[0], out x);
            Int32.TryParse(coordinates[1], out y);
            return new Coordinates(x, y);
        }
    }
}