using Rover.Models;
using System;

namespace Rover
{
    public static class CommandHelper
    {
        public static int GetNumber(string input)
        {
            return Convert.ToInt32(input);
        }

        public static void CheckInputStringForDirections(string input)
        {
            var inputArr = input.ToCharArray();
            Command c;
            foreach (var key in inputArr)
            {
                if (!Enum.TryParse(key.ToString(), false, out c))
                    throw new FormatException();
            }
        }

        public static void ValidateSurfaceCommand(string[] input)
        {
            try
            {
                GetNumber(input[0]);
                GetNumber(input[1]);
            }
            catch
            {
                throw new FormatException();
            }
        }

        public static void ValidateStartingPointCommand(string[] input)
        {
            try
            {
                GetNumber(input[0]);
                GetNumber(input[1]);
                Direction d;
                if (!Enum.TryParse(input[2], false, out d))
                    throw new FormatException();
            }
            catch
            {
                throw new FormatException();
            }
        }
    }
}
