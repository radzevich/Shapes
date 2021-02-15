using System;

namespace Shapes.Shapes
{
    public class Line : IShape
    {
        public Point A { get; }
        public Point B { get; }

        public Line(Point A, Point B)
        {
            this.A = A ?? throw new ArgumentNullException(nameof(A));
            this.B = B ?? throw new ArgumentNullException(nameof(B));
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