using Rover.Models;
using System;

namespace Rover
{
    public class DirectionsCommand : CommandBase, IConsoleCommand
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

   
}
