namespace Rover.States
{
    public abstract class RoverState
    {
        protected Rover rover;

        public RoverState(Rover rover)
        {
            this.rover = rover;
        }
        public abstract void MoveForward();
        public abstract void MoveLeft();
        public abstract void MoveRight();

    }
}
