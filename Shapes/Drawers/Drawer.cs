using System.Text;
using Shapes.Shapes;

namespace Shapes.Drawers
{
    public class Drawer
    {
        private readonly IImageStore[] _imageStores;

        public Drawer(params IImageStore[] imageStores)
        {
            _imageStores = imageStores;
        }

        public void Draw(IShape shape)
        {
            var shapeName = shape.GetType().Name;
            var shapePoints = shape.GetPoints();

            var sb = new StringBuilder($"{shapeName}. ");

            foreach (var shapePoint in shapePoints)
            {
                sb = sb.Append(shapePoint);
            }

            Draw(sb.ToString());
        }

        private void Draw(string logMessage)
        {
            foreach (var imageStore in _imageStores)
            {
                imageStore.Draw(logMessage);
            }
        }
    }
}