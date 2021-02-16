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
            var width = A.GetXDistance(B);
            var height = A.GetYDistance(B);

            return width * height;
        }

        public double GetPerimeter()
        {
            var width = A.GetXDistance(B);
            var height = A.GetYDistance(B);

            return (width + height) * 2;
        }

        public Point[] GetPoints()
        {
            return new[] { A, B };
        }
    }
}