namespace Minesweeper4
{
    public class Grid
    {
        private readonly int _width;
        private readonly int _height;

        public Grid(int width, int height)
        {
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
            return this;
        }
    }
}
