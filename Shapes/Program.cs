using System;
using System.Collections.Generic;
using Shapes.Drawers;
using Shapes.Shapes;
using Shapes.View;
using Shapes.View.Models;

namespace Shapes
{
    class Program
    {
        private static bool _userRequestedExit;

        private static List<IShape> _shapesStore = new List<IShape>();

        private static readonly Drawer _drawer = new Drawer(
            new ConsoleImageStore(),  // log data in console
            new FileImageStore());    // log data in file

        static void Main(string[] args)
        {
            var controller = new ConsoleController();

            controller.OnUserCreatedShape += OnDrawShape;
            controller.OnUserCreatedShape += OnDrawShapeFromListCommand;
            controller.OnUserCreatedShape += OnList;
            controller.OnUserCreatedShape += OnExit;

            try
            {
                do
                {
                    controller.WaitUserInput();
                }
                while (!_userRequestedExit);
            }
            finally
            {
                controller.OnUserCreatedShape -= OnDrawShape;
                controller.OnUserCreatedShape -= OnDrawShapeFromListCommand;
                controller.OnUserCreatedShape -= OnList;
                controller.OnUserCreatedShape -= OnExit;
            }
        }

        /// <summary>
        /// Draw the specified shape.
        /// Command like: "draw rectangle (1,3) (4,8)"
        /// </summary>
        /// <param name="command"></param>
        private static void OnDrawShape(ICommand command)
        {
            if (!(command is DrawShapeCommand drawShapeCommand))
            {
                return;
            }

            var shape = ShapeFactory.CreateShape(drawShapeCommand.Args.ShapeName, drawShapeCommand.Args.ShapePoints);

            _drawer.Draw(shape);
            _shapesStore.Add(shape);
        }

        /// <summary>
        /// Draw the shape from the list of already drawn shapes.
        /// Command like: "draw 3" or "draw -2"
        /// </summary>
        /// <param name="command"></param>
        private static void OnDrawShapeFromListCommand(ICommand command)
        {
            if (!(command is DrawShapeFromListCommand drawShapeFromListCommand))
            {
                return;
            }

            var index = drawShapeFromListCommand.Args.PositionInList >= 0
                ? drawShapeFromListCommand.Args.PositionInList
                : _shapesStore.Count + drawShapeFromListCommand.Args.PositionInList;

            if (index < 0 || index >= _shapesStore.Count)
            {
                throw new ArgumentOutOfRangeException($"{index} is out of shapes store size");
            }

            var shape = _shapesStore[index];

            _drawer.Draw(shape);
        }

        /// <summary>
        /// Draw all shapes which already were drawn
        /// Command like: "list"
        /// </summary>
        /// <param name="command"></param>
        private static void OnList(ICommand command)
        {
            if (command is ListCommand)
            {
                foreach (var shape in _shapesStore)
                {
                    _drawer.Draw(shape);
                }
            }
        }

        /// <summary>
        /// Finish the program.
        /// Command like: "exit"
        /// </summary>
        /// <param name="command"></param>
        private static void OnExit(ICommand command)
        {
            if (command is ExitCommand)
            {
                _userRequestedExit = true;
            }
        }
    }
}