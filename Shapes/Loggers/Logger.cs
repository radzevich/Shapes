using System.Text;
using Shapes.Shapes;

namespace Shapes.Loggers
{
    public abstract class Logger
    {
        public void Log(IShape shape)
        {
            var shapeName = shape.GetType().Name;
            var shapePoints = shape.GetPoints();

            var sb = new StringBuilder($"{shapeName}. ");

            foreach (var shapePoint in shapePoints)
            {
                sb = sb.Append(shapePoint);
            }

            LogMessage(sb.ToString());
        }

        protected abstract void LogMessage(string message);
    }
}