using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Shapes.Exceptions;
using Shapes.Shapes;
using Shapes.View.Models;

namespace Shapes.View
{
    public static class InputParser
    {
        private const string UserInputPattern = @"(?<command>\w+)\s+(?<args>.+)";
        private const string PointCoordinatesPattern = @"(?<x>\d+)\s*,\s*(?<y>\d+)";

        private static readonly Regex _userInputRegex = new Regex(UserInputPattern);
        private static readonly Regex _pointCoordinatesRegex = new Regex(PointCoordinatesPattern);

        public static ICommand ParseUserInput(string userInput)
        {
            var commandName = userInput;
            var commandArgs = new string[0];

            // parse input string using regular expression
            var match = _userInputRegex.Match(userInput);
            if (match.Success)
            {
                // extract command name and list of arguments from the parsed string
                commandName = match.Groups["command"].Value;
                commandArgs = match.Groups.ContainsKey("args")
                    ? match.Groups["args"].Value.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    : new string[0];
            }

            return ParseCommandArgs(commandName, commandArgs);
        }

        private static ICommand ParseCommandArgs(string commandName, string[] args)
        {
            return commandName switch
            {
                DrawCommand.Name => CreateDrawCommand(args),
                ListCommand.Name => CreateListCommand(),
                ExitCommand.Name => CreateExitCommand(),
                _ => throw new InvalidCommandException(commandName)
            };
        }

        private static Point ParsePoint(string source)
        {
            // parse input string using regular expression
            var match = _pointCoordinatesRegex.Match(source);
            if (!match.Success)
            {
                throw new InvalidCoordinatesException(source);
            }

            // extract x and y from the parsed string
            var x = match.Groups["x"].Value;
            var y = match.Groups["y"].Value;

            if (!int.TryParse(x, out var xValue) || !int.TryParse(y, out var yValue))
            {
                throw new InvalidCoordinatesException(source);
            }

            return new Point(xValue, yValue);
        }

        private static DrawCommand CreateDrawCommand(string[] args)
        {
            ThrowIfNullOrEmpty(args, nameof(args));

            if (int.TryParse(args[0], out var index))
            {
                // draw 4
                return CreateDrawShapeFromListCommand(index);
            }
            else
            {
                // draw rectangle (1,3) (4,6)
                return CreateDrawShapeCommand(args[0], args.Skip(1).ToArray());
            }
        }

        private static DrawShapeFromListCommand CreateDrawShapeFromListCommand(int positionInList)
        {
            var args = new DrawShapeFromListCommandArgs(positionInList);
            var command = new DrawShapeFromListCommand(args);

            return command;
        }

        private static DrawShapeCommand CreateDrawShapeCommand(string shapeName, string[] pointArgs)
        {
            ThrowIfNull(shapeName, nameof(shapeName));
            ThrowIfNull(pointArgs, nameof(pointArgs));

            var points = new Point[pointArgs.Length];
            for (var i = 0; i < points.Length; i++)
            {
                points[i] = ParsePoint(pointArgs[i]);
            }

            var args = new DrawShapeCommandArgs(shapeName, points);
            var command = new DrawShapeCommand(args);

            return command;
        }

        private static ListCommand CreateListCommand()
        {
            return new ListCommand();
        }

        private static ICommand CreateExitCommand()
        {
            return new ExitCommand();
        }

        private static void ThrowIfNull(object obj, string name)
        {
            if (obj == null)
            {
                throw new ArgumentException($"{name} parameter is required");
            }
        }

        private static void ThrowIfNullOrEmpty<T>(IEnumerable<T> collection, string name)
        {
            if (collection == null || !collection.Any())
            {
                throw new ArgumentException($"{name} parameter is required");
            }
        }
    }
}