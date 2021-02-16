using Shapes.Shapes;

namespace Shapes.View.Models
{
    public class DrawShapeCommandArgs
    {
        public string ShapeName { get; }

        public Point[] ShapePoints { get; }

        public DrawShapeCommandArgs(string shapeName, Point[] shapePoints)
        {
            ShapeName = shapeName;
            ShapePoints = shapePoints;
        }
    }
}