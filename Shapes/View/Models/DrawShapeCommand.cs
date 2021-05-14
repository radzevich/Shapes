namespace Shapes.View.Models
{
    public class DrawShapeCommand : DrawCommand
    {
        public DrawShapeCommandArgs Args { get; }

        public DrawShapeCommand(DrawShapeCommandArgs args)
        {
            Args = args;
        }
    }
}