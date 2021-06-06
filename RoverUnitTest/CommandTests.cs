using NUnit.Framework;
using Rover;
using Rover.Models;

namespace RoverUnitTest
{
    public class OperationCenterTests
    {
        [Test]
        public void OperationCenterExecuteCommandTest()
        {
            var rover = new Rover.Rover();
            var operationCenter = new OperationCenter(rover);
            string setSurfaceCommand = "5 5";
            var command = CommandFactory.GetConsoleCommand(setSurfaceCommand);
            operationCenter.ExecuteCommand(command);
            Assert.IsNotNull(rover.Surface);
        }

        [Test]
        public void OperationCenterGetLastSpotTest()
        {
            var rover = new Rover.Rover();
            var operationCenter = new OperationCenter(rover);

            string setSurfaceCommand = "5 5";
            var command = CommandFactory.GetConsoleCommand(setSurfaceCommand);

            operationCenter.ExecuteCommand(command);

            string setStartingPointCommand = "1 2 N";
            command = CommandFactory.GetConsoleCommand(setStartingPointCommand);
            operationCenter.ExecuteCommand(command);

            var directionsCommand = "LMLMLMLMM";
            command = CommandFactory.GetConsoleCommand(directionsCommand);
            operationCenter.ExecuteCommand(command);

            Assert.AreEqual(operationCenter.GetLastSpot(), "1 3 N");
        }
    }
}