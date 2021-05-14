namespace Shapes.View.Models
{
    public class DrawShapeFromListCommandArgs : DrawCommand
    {
        public int PositionInList { get; }

        public DrawShapeFromListCommandArgs(int positionInList)
        {
            PositionInList = positionInList;
        }
    }
}