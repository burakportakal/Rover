using Rover.Models;

namespace Rover.States
{
    public class EastState : RoverState
    {
        public EastState(Rover rover) : base(rover)
        {
        }
        public override void MoveForward()
        {
            if (rover.CurrentPointX == rover.Surface.X)
                return;

            rover.CurrentPointX += 1;
        }

        public override void MoveLeft()
        {
            rover.SetState(new NorthState(rover));
            rover.SetDirection(Direction.N);
        }

        public override void MoveRight()
        {
            rover.SetState(new SouthState(rover));
            rover.SetDirection(Direction.S);
        }
    }
}
