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
            try
            {
                string surfaceLength = ReadFromConsole();
                var operationCenter = new OperationCenter(new Rover());
                var surfaceCommand = CommandFactory.GetConsoleCommand(surfaceLength);
                if (surfaceCommand is not SetSurfaceCommand)
                {
                    throw new FormatException();
                }

                operationCenter.ExecuteCommand(surfaceCommand);

                while (true)
                {
                    try
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
                        
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("The input string was not in correct format. Please try again.");
                        continue;
                    }
                    catch
                    {
                        Console.WriteLine("An error occured. Please try again.");
                        continue;
                    }
                    finally
                    {
                        operationCenter.SetRover(new Rover());
                        operationCenter.ExecuteCommand(surfaceCommand);
                    }
                }
            }
            catch(FormatException)
            {
                Console.WriteLine("The input string was not in correct format. Please try again.");
            }
            catch
            {
                Console.WriteLine("An error occured. Please try again.");
            }
            finally
            {
                Start();
            }
        }

        static void ExecuteConsoleCommand(string input, OperationCenter operationCenter)
        {
            try
            {
                var command = CommandFactory.GetConsoleCommand(input);
                operationCenter.ExecuteCommand(command);
            }
            catch
            {
                throw;
            }

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
