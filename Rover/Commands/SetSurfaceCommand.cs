using System;

namespace Rover
{
    public class SetSurfaceCommand : CommandBase, IConsoleCommand
    {
        public SetSurfaceCommand(object commandText) : base(commandText) { }
        public void Execute(IRover rover)
        {
            var commandArr = InputCommand as string[];
            var surface = new Surface(CommandHelper.GetNumber(commandArr[0]), CommandHelper.GetNumber(commandArr[1]));
            rover.SetSurface(surface);
        }
    }
}
