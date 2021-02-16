using System;
using System.Linq;
using Shapes.Shapes;

namespace Shapes
{
    public class ConsoleController
    {
        public delegate void OnUserCreateShapeDelegate(IShape shape);

        public event OnUserCreateShapeDelegate OnUserCreateShape;

        private readonly string[] _shapeNames = {
            nameof(Rectangle).ToLower(),
            nameof(Triangle).ToLower(),
            nameof(Line).ToLower(),
        };

        public void WaitUserInput()
        {
            var rectangle = new Rectangle(new Point(1, 3), new Point(4, 6));

            if (OnUserCreateShape != null) // if nobody is subscribed on event, it will be null
            {
                OnUserCreateShape(rectangle);
            }
        }
    }
}