using Rover.Models;

namespace Rover.States
{
    public class NorthState : RoverState
    {
        public NorthState(Rover rover): base(rover)
        {
        }
        public override void MoveForward()
        {
            if (rover.CurrentPointY == rover.Surface.Y)
                return;

            rover.CurrentPointY += 1;
        }

        public override void MoveLeft()
        {
            rover.SetState(new WestState(rover));
            rover.SetDirection(Direction.W);
        }

        public override void MoveRight()
        {
            rover.SetState(new EastState(rover));
            rover.SetDirection(Direction.E);
        }
    }
}
