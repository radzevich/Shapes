using System;

namespace Shapes.Exceptions
{
    public class InvalidCoordinatesException : Exception
    {
        public string Coordinates { get; }

        public InvalidCoordinatesException(string coordinates)
        {
            Coordinates = coordinates;
        }
    }
}