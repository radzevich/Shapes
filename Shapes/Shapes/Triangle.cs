using System;

namespace Shapes.Shapes
{
    public class Triangle : IShape
    {
        public Point A { get; }
        public Point B { get; }
        public Point C { get; }

        public Triangle(Point a, Point b, Point c)
        {
            A = a ?? throw new ArgumentNullException(nameof(a));
            B = b ?? throw new ArgumentNullException(nameof(b));
            C = c ?? throw new ArgumentNullException(nameof(c));
        }
        
        public  Point[] GetPoints()
        {
            return new[] { A, B, C };
        }

        public double GetSquare()
        {
            throw new NotImplementedException();
        }

        public double GetPerimeter()
        {
            return A.GetDistance(B) +
                   B.GetDistance(C) +
                   C.GetDistance(A);
        }
    }
}