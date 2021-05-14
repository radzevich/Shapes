using System;
using Shapes.Exceptions;
using Shapes.View.Models;

namespace Shapes.View
{
    public class ConsoleController
    {
        public delegate void OnUserInputDelegate(ICommand command);
        public event OnUserInputDelegate OnUserCreatedShape;

        public void WaitUserInput()
        {
            try
            {
                var userInput = Console.ReadLine().Trim().ToLower();

                var command = InputParser.ParseUserInput(userInput);

                if (OnUserCreatedShape != null) // if nobody is subscribed on event, it will be null
                {
                    OnUserCreatedShape(command);
                }
            }
            catch (InvalidCommandException ex)
            {
                Console.WriteLine($"Invalid command: {ex.Command}");
            }
            catch (InvalidCoordinatesException ex)
            {
                Console.WriteLine($"Invalid coordinates specified: {ex.Coordinates}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Invalid command arguments: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unhandled exception: {ex.Message}");
            }
        }
    }
}