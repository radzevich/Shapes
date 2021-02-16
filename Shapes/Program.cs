using Shapes.Loggers;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            var controller = new ConsoleController();

            var fileLogger = LoggerFactory.CreateLogger(useFile: true);
            var consoleLogger = LoggerFactory.CreateLogger(useFile: false);

            controller.OnUserCreateShape += fileLogger.Log;
            controller.OnUserCreateShape += consoleLogger.Log;

            controller.WaitUserInput();

            controller.OnUserCreateShape -= fileLogger.Log;

            controller.WaitUserInput();
        }
    }
}