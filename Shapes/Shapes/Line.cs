using System;

namespace Shapes.Shapes
{
    public class Line : Shape
    {
        public Point A { get; }
        public Point B { get; }

        public Line(Point A, Point B)
        {
            this.A = A ?? throw new ArgumentNullException(nameof(A));
            this.B = B ?? throw new ArgumentNullException(nameof(B));
        }
        
        public override double GetSquare()
        {
            return 0;
        }

        public override double GetPerimeter()
        {
            return A.GetDistance(B);
        }

        public override Point[] GetPoints()
        {
            return new[] {A, B};
        }
    }
}