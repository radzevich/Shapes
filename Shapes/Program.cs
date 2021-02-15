using Shapes.Loggers;
using Shapes.Shapes;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            var controller = new ConsoleController();

            var fileLogger = LoggerFactory.CreateLogger(true);
            var consoleLogger = LoggerFactory.CreateLogger(false);

            controller.OnUserCreateShape += fileLogger.Log;
            controller.OnUserCreateShape += consoleLogger.Log;

            controller.OnUserCreateShape -= fileLogger.Log;

            // controller.WaitUserInput();

            // var logger = LoggerFactory.CreateLogger(true);
            // var line = new Line(new Point(1, 2), new Point(3, 5));
            //
            // logger.Log(line);
        }
    }
}