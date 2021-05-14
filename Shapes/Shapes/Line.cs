using System;

namespace Shapes.Shapes
{
    public class Line : IShape
    {
        public Point A { get; }
        public Point B { get; }

        public Line(Point a, Point b)
        {
            A = a ?? throw new ArgumentNullException(nameof(a));
            B = b ?? throw new ArgumentNullException(nameof(b));
        }
        
        public double GetSquare()
        {
            return 0;
        }

        public double GetPerimeter()
        {
            return A.GetDistance(B);
        }

        public Point[] GetPoints()
        {
            return new[] {A, B};
        }
    }
}