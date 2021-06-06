using Rover.Models;

namespace Rover.States
{
    public class WestState : RoverState
    {
        public WestState(Rover rover) : base(rover)
        {
        }
        public override void MoveForward()
        {
            if (rover.CurrentPointX == 0)
                return;

            rover.CurrentPointX -= 1;
        }

        public override void MoveLeft()
        {
            rover.SetState(new SouthState(rover));
            rover.SetDirection(Direction.S);
        }

        public override void MoveRight()
        {
            rover.SetState(new NorthState(rover));
            rover.SetDirection(Direction.N);
        }
    }
}
