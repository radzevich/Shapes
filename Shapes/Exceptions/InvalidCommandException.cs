using System;

namespace Shapes.Exceptions
{
    public class InvalidCommandException : Exception
    {
        public string Command { get; }

        public InvalidCommandException(string command)
        {
            Command = command;
        }
    }
}