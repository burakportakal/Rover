using Rover.Models;

namespace Rover.States
{
    public class SouthState : RoverState
    {
        public SouthState(Rover rover) : base(rover)
        {
        }
        public override void MoveForward()
        {
            if (rover.CurrentPointY == 0)
                return;

            rover.CurrentPointY -= 1;
        }

        public override void MoveLeft()
        {
            rover.SetState(new EastState(rover));
            rover.SetDirection(Direction.E);
        }

        public override void MoveRight()
        {
            rover.SetState(new WestState(rover));
            rover.SetDirection(Direction.W);
        }
    }
}
