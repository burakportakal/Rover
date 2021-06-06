using System;

namespace Rover
{

    public class SetStartingPointCommand : CommandBase, IConsoleCommand
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
}
