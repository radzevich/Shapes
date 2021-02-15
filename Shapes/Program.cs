using Shapes.Loggers;
using Shapes.Shapes;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = LoggerFactory.CreateLogger(true);
            var line = new Line(new Point(1, 2), new Point(3, 5));

            logger.Log(line);
        }
    }
}