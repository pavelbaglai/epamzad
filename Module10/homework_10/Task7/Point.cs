using System;

namespace homework_10.Task7
{
    public struct Point : IComparable<Point>
    {
        private int _x;
        private int _y;

        public Point(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public int CompareTo(Point other)
        {
            var xComparison = _x.CompareTo(other._x);
            if (xComparison != 0) return xComparison;
            return _y.CompareTo(other._y);
        }
    }
}