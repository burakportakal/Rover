using NUnit.Framework;
using Rover.States;

namespace RoverUnitTest
{
    public class RoverStateTests
    {
        [Test]
        public void EastStateTest()
        {
            var rover = new Rover.Rover();
            rover.SetSurface(new Rover.Surface { X = 5, Y = 5 });
            rover.SetPointAndDirection(1, 2, "E");

            var eastState = new EastState(rover);

            eastState.MoveForward();

            Assert.AreEqual(rover.CurrentPointX, 2);

            eastState.MoveLeft();
            Assert.IsInstanceOf(typeof(NorthState), rover.RoverState);
            eastState.MoveRight();
            Assert.IsInstanceOf(typeof(SouthState), rover.RoverState);
        }
        [Test]
        public void WestStateTest()
        {
            var rover = new Rover.Rover();
            rover.SetSurface(new Rover.Surface { X = 5, Y = 5 });
            rover.SetPointAndDirection(1, 2, "W");

            var westState = new WestState(rover);

            westState.MoveForward();

            Assert.AreEqual(rover.CurrentPointX, 0);

            westState.MoveLeft();
            Assert.IsInstanceOf(typeof(SouthState), rover.RoverState);
            westState.MoveRight();
            Assert.IsInstanceOf(typeof(NorthState), rover.RoverState);
        }
        [Test]
        public void NorthStateTest()
        {
            var rover = new Rover.Rover();
            rover.SetSurface(new Rover.Surface { X = 5, Y = 5 });
            rover.SetPointAndDirection(1, 2, "N");

            var northState = new NorthState(rover);

            northState.MoveForward();

            Assert.AreEqual(rover.CurrentPointY, 3);

            northState.MoveLeft();
            Assert.IsInstanceOf(typeof(WestState), rover.RoverState);
            northState.MoveRight();
            Assert.IsInstanceOf(typeof(EastState), rover.RoverState);
        }
        [Test]
        public void SouthStateTest()
        {
            var rover = new Rover.Rover();
            rover.SetSurface(new Rover.Surface { X = 5, Y = 5 });
            rover.SetPointAndDirection(1, 2, "S");

            var northState = new SouthState(rover);

            northState.MoveForward();

            Assert.AreEqual(rover.CurrentPointY, 1);

            northState.MoveLeft();
            Assert.IsInstanceOf(typeof(EastState), rover.RoverState);
            northState.MoveRight();
            Assert.IsInstanceOf(typeof(WestState), rover.RoverState);
        }

    }
}
