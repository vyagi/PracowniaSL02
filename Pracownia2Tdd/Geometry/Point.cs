using System;

namespace Geometry
{
    public class Point
    {
        private readonly double _x;
        private readonly double _y;

        public Point(double x, double y)
        {
            _x = x;
            _y = y;
        }

        public Point() : this(1,1) { }
        
        public double X => _x;

        public double Y => _y;

        public double Distance() => Math.Sqrt(_x * _x + _y * _y);

        public double Distance(Point point1) =>
            Math.Sqrt(Math.Pow(_x - point1._x, 2) + Math.Pow(_y - point1._y, 2));

        public static double Distance(Point point1, Point point2) => point1.Distance(point2);

        public override string ToString() => $"({_x},{_y})";

        public enum ReflectionType
        {
            X,
            Y,
            Origin
        }

        public Point Reflect(ReflectionType reflectionType) =>
            reflectionType switch
            {
                ReflectionType.X => new Point(_x, -_y),
                ReflectionType.Y => new Point(-_x, _y),
                ReflectionType.Origin => new Point(-_x, -_y),
                _ => throw new ArgumentOutOfRangeException(nameof(reflectionType), reflectionType, null)
            };
    }
}
