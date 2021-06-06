using Rover.Models;
using Rover.States;
using System;

namespace Rover
{
    public class Rover : IRover
    {
        public Surface Surface { get; private set; }
        public Direction Direction { get; private set; }
        public int CurrentPointX { get; set; }
        public int CurrentPointY { get; set; }
        public RoverState RoverState { get; set; }
        
        public Rover() {}
        public Rover(Surface surface)
        {
            Surface = surface;
        }

        public void SetSurface(Surface surface)
        {
            Surface = surface;
        }

        public void SetState(RoverState state)
        {
            RoverState = state;
        }

        public void SetPointAndDirection(int x, int y, string direction)
        {
            Direction = Enum.Parse<Direction>(direction);
            switch (Direction)
            {
                case Direction.N:
                    RoverState = new NorthState(this);
                    break;
                case Direction.W:
                    RoverState = new WestState(this);
                    break;
                case Direction.S:
                    RoverState = new SouthState(this);
                    break;
                case Direction.E:
                    RoverState = new EastState(this);
                    break;
            }

            this.CurrentPointX = x;
            this.CurrentPointY = y;
        }

        public override string ToString()
        {
            return $"{CurrentPointX} {CurrentPointY} {Direction}";
        }

        public void SetDirection(Direction direction)
        {
            this.Direction = direction;
        }

        public void MoveForward()
        {
            this.RoverState.MoveForward();
        }

        public void MoveLeft()
        {
            this.RoverState.MoveLeft();
        }

        public void MoveRight()
        {
            this.RoverState.MoveRight();
        }
    }
}
