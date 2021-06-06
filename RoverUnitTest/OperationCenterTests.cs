using NUnit.Framework;
using Rover;
using Rover.Models;

namespace RoverUnitTest
{
    public class CommandTests
    {
        [Test]
        public void SetSurfaceCommandTest()
        {
            string setSurfaceCommand = "5 5";
            var command = CommandFactory.GetConsoleCommand(setSurfaceCommand);
            Assert.IsAssignableFrom(typeof(SetSurfaceCommand), command);
            var rover = new Rover.Rover();
            command.Execute(rover);
            Assert.IsNotNull(rover.Surface);
        }

        [Test]
        public void SetStartingPointCommandTest()
        {
            string setStartingPointCommand = "1 2 N";
            var command = CommandFactory.GetConsoleCommand(setStartingPointCommand);
            Assert.IsAssignableFrom(typeof(SetStartingPointCommand), command);
            var rover = new Rover.Rover();
            command.Execute(rover);
            Assert.AreEqual(rover.CurrentPointX, 1);
            Assert.AreEqual(rover.CurrentPointY, 2);
            Assert.AreEqual(rover.Direction, Direction.N);
        }

        [Test]
        public void DirectionsCommandTest()
        {
            string setSurfaceCommand = "5 5";
            var command = CommandFactory.GetConsoleCommand(setSurfaceCommand);
            var rover = new Rover.Rover();
            command.Execute(rover);

            string setStartingPointCommand = "1 2 N";
            command = CommandFactory.GetConsoleCommand(setStartingPointCommand);
            command.Execute(rover);

            var directionsCommand = "LMLMLMLMM";
            command = CommandFactory.GetConsoleCommand(directionsCommand);
            command.Execute(rover);
            Assert.AreEqual(rover.ToString(), "1 3 N");
        }
    }
}