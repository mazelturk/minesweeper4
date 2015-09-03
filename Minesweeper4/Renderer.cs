using System.Linq;
using System.Runtime.Serialization.Formatters;

namespace Minesweeper4
{
    public class Renderer
    {
        public static string RenderGrid(Grid grid)
        {
            var height = grid.Height;
            var width = grid.Width;
            var output = Enumerable.Range(0, height)
                .Select(rowIndex => RenderRow(width, grid, rowIndex));
     
            return string.Join("", output);
        }

        private static string RenderRow(int width, Grid grid, int rowIndex)
        {
            var columns = Enumerable.Range(0, width)
                .Select(columnIndex => RenderPoint(new GridView(grid), rowIndex, columnIndex));

            return string.Join("", columns) + "\n";
        }

        private static string RenderPoint(GridView grid, int rowIndex, int columnIndex)
        {
            var point = grid.Point(rowIndex: rowIndex, columnIndex: columnIndex);
            return point.Accept(new PointVisitor());
        }

        private class PointVisitor : IPointViewVisitor<string>
        {
            public string Visit(ZeroMines pointView)
            {
                return "x";
            }
            
            public string Visit(Unexplored pointView)
            {
                return "_";
            } 
            
            public string Visit(ExploredMine pointView)
            {
                return "*";
            }

            public string Visit(NumberOfMines pointView)
            {
                return pointView.Count.ToString();
            }
        }
    }

    public class GridView
    {
        private readonly Grid _grid;

        public GridView(Grid grid)
        {
            _grid = grid;
        }

        public IPointView Point(int rowIndex, int columnIndex)
        {
            return !_grid.IsExplored(new Coordinates(columnIndex, rowIndex))
                ? new Unexplored()
                :  _grid.IsMine(new Coordinates(columnIndex, rowIndex)) ? new ExploredMine()
                    : _grid.CountSurroundingMines(new Coordinates(columnIndex, rowIndex)) == 0 ? (IPointView) new ZeroMines() : 
                    new NumberOfMines(_grid.CountSurroundingMines(new Coordinates(columnIndex, rowIndex)));
            
        }
    }

    public interface IPointView
    {
        T Accept<T>(IPointViewVisitor<T> visitor);
    }

    public interface IPointViewVisitor<T>
    {
        T Visit(ZeroMines pointView);
        T Visit(NumberOfMines pointView);
        T Visit(Unexplored pointView);
        T Visit(ExploredMine pointView);
    }

    public class ZeroMines : IPointView
    {
        public T Accept<T>(IPointViewVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
    
    public class Unexplored : IPointView
    {
        public T Accept<T>(IPointViewVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
    
    public class ExploredMine : IPointView
    {
        public T Accept<T>(IPointViewVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }

    public class NumberOfMines : IPointView
    {
        private readonly int _count;

        public NumberOfMines(int count)
        {
            _count = count;
        }

        public int Count { get { return _count; } }

        public T Accept<T>(IPointViewVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}