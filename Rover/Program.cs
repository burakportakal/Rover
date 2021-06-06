using System;

namespace Rover
{
    class Program
    {
        static void Main(string[] args)
        {
            Start();
        }

        static void Start()
        {
            
            string surfaceLength = ReadFromConsole();
            var operationCenter = new OperationCenter(new Rover());
            var surfaceCommand = CommandFactory.GetConsoleCommand(surfaceLength);
            operationCenter.ExecuteCommand(surfaceCommand);

            while (true)
            {
                string input = ReadFromConsole();

                if (string.IsNullOrEmpty(input))
                    continue;

                ExecuteConsoleCommand(input, operationCenter);

                input = ReadFromConsole();

                if (string.IsNullOrEmpty(input))
                    continue;

                ExecuteConsoleCommand(input, operationCenter);
                WriteToConsole(operationCenter.GetLastSpot());
                operationCenter.SetRover(new Rover());
                operationCenter.ExecuteCommand(surfaceCommand);
            }
        }

        static void ExecuteConsoleCommand(string input, OperationCenter operationCenter)
        {

            var command = CommandFactory.GetConsoleCommand(input);
            operationCenter.ExecuteCommand(command);
            //if (command.Contains(' '))
            //{
            //    var commandArr = command.Split(' ');
            //    if (commandArr.Length == 2)
            //    {
            //        operationCenter.SetSurface(commandArr);
            //    }
            //    else if (commandArr.Length == 3)
            //    {
            //        operationCenter.SetStartingPoint(commandArr);
            //    }
            //}
            //else
            //{
            //    var commandArr = command.ToCharArray();
            //    operationCenter.SendCommand(commandArr);
            //}
        }

        static void WriteToConsole(string output)
        {
            Console.WriteLine(output);
        }

        static string ReadFromConsole()
        {
            return Console.ReadLine();
        }
    }
}
