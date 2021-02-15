using System;

namespace Shapes.Shapes
{
    public class Rectangle : IShape
    {
        public Point A { get; }
        public Point B { get; }

        public Rectangle(Point a, Point b)
        {
            A = a ?? throw new ArgumentNullException(nameof(a));
            B = b ?? throw new ArgumentNullException(nameof(b));
        }
        
        public double GetSquare()
        {
            var width = GetWidth();
            var height = GetHeight();

            return width * height;
        }

        public double GetPerimeter()
        {
            var width = GetWidth();
            var height = GetHeight();

            return (width + height) * 2;
        }

        public Point[] GetPoints()
        {
            return new[] { A, B };
        }

        private int GetWidth()
        {
            return Math.Abs(A.X - B.X);
        }

        private int GetHeight()
        {
            return Math.Abs(A.Y - B.Y);
        }
    }
}