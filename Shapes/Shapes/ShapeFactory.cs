using System;

namespace Shapes.Shapes
{
    public static class ShapeFactory
    {
        public static IShape CreateShape(string shapeName, Point[] points)
        {
            shapeName = shapeName?.Trim().ToLower();

            if (shapeName == nameof(Rectangle).ToLower())
            {
                return CreateRectangle(points);
            }

            if (shapeName == nameof(Triangle).ToLower())
            {
                return CreateTriangle(points);
            }

            if (shapeName == nameof(Line).ToLower())
            {
                return CreateLine(points);
            }

            throw new NotSupportedException($"{shapeName} is not supported");
        }

        private static Line CreateLine(Point[] points)
        {
            ThrowIfNotEnoughPoints(nameof(Line), points, 2);

            return new Line(points[0], points[1]);
        }

        private static Rectangle CreateRectangle(Point[] points)
        {
            ThrowIfNotEnoughPoints(nameof(Rectangle), points, 2);

            return new Rectangle(points[0], points[1]);
        }

        private static Triangle CreateTriangle(Point[] points)
        {
            ThrowIfNotEnoughPoints(nameof(Triangle), points, 3);

            return new Triangle(points[0], points[1], points[2]);
        }

        private static void ThrowIfNotEnoughPoints(string shapeName, Point[] points, int expectedNumberOfPoints)
        {
            if (points == null || points.Length < expectedNumberOfPoints)
            {
                throw new ArgumentException($"{shapeName} requires {expectedNumberOfPoints} points");
            }
        }
    }
}