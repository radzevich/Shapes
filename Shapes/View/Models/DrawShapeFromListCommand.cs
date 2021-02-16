namespace Shapes.View.Models
{
    public class DrawShapeFromListCommand : DrawCommand
    {
        public DrawShapeFromListCommandArgs Args { get; }

        public DrawShapeFromListCommand(DrawShapeFromListCommandArgs args)
        {
            Args = args;
        }
    }
}