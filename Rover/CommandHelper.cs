using System;

namespace Rover
{
    public static class CommandHelper
    {
        public static int GetNumber(string input)
        {
            return Convert.ToInt32(input);
        }
    }

    public interface ConsoleCommand
    {
        void Execute(IRover rover);
    }

    public abstract class CommandBase
    {
        public CommandBase(object inputCommand)
        {
            InputCommand = inputCommand;
        }
        public object InputCommand { get; set; }
    }

    public class SetSurfaceCommand : CommandBase, ConsoleCommand
    {
        public SetSurfaceCommand(object commandText) : base(commandText) { }
        public void Execute(IRover rover)
        {
            var commandArr = InputCommand as string[];
            var surface = new Surface(CommandHelper.GetNumber(commandArr[0]), CommandHelper.GetNumber(commandArr[1]));
            rover.SetSurface(surface);
        }
    }

    public class SetStartingPointCommand : CommandBase, ConsoleCommand
    {
        public SetStartingPointCommand(object commandText) : base(commandText) { }
        public void Execute(IRover rover)
        {
            var commandArr = InputCommand as string[];
            int point1 = CommandHelper.GetNumber(commandArr[0]);
            int point2 = CommandHelper.GetNumber(commandArr[1]);
            string direction = commandArr[2];

            rover.SetPointAndDirection(point1, point2, direction);
        }
    }

    public class DirectionsCommand : CommandBase, ConsoleCommand
    {
        public DirectionsCommand(object commandText) : base(commandText) { }
        public void Execute(IRover rover)
        {
            var commandArr = InputCommand.ToString().ToCharArray();
            for (var i = 0; i < commandArr.Length; i++)
            {
                var direction = Enum.Parse<Command>(commandArr[i].ToString());
                switch (direction)
                {
                    case Command.L:
                        rover.MoveLeft();
                        break;
                    case Command.R:
                        rover.MoveRight();
                        break;
                    case Command.M:
                        rover.MoveForward();
                        break;
                }
            }
        }
    }

    public static class CommandFactory
    {
        public static ConsoleCommand GetConsoleCommand(string command)
        {
            if (command.Contains(' '))
            {
                var commandArr = command.Split(' ');
                if (commandArr.Length == 2)
                {
                    return new SetSurfaceCommand(commandArr);
                }
                else if (commandArr.Length == 3)
                {
                    return new SetStartingPointCommand(commandArr);
                }
            }
            return new DirectionsCommand(command);
        }
    }
}
