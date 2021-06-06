using System;

namespace Rover
{
    public static class CommandFactory
    {
        public static IConsoleCommand GetConsoleCommand(string command)
        {
            if (command.Contains(' '))
            {
                var commandArr = command.Split(' ');
                if (commandArr.Length == 2)
                {
                    CommandHelper.ValidateSurfaceCommand(commandArr);
                    return new SetSurfaceCommand(commandArr);
                }
                else if (commandArr.Length == 3)
                {
                    CommandHelper.ValidateStartingPointCommand(commandArr);
                    return new SetStartingPointCommand(commandArr);
                }
            }
            CommandHelper.CheckInputStringForDirections(command);
            return new DirectionsCommand(command);
        }
    }
}
