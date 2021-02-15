using System;

namespace Shapes.Loggers
{
    public class ConsoleLogger : Logger
    {
        protected override void LogMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}