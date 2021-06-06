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
        private RoverState _roverState;
        
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
            _roverState = state;
        }

        public void SetPointAndDirection(int x, int y, string direction)
        {
            Direction = Enum.Parse<Direction>(direction);
            switch (Direction)
            {
                case Direction.N:
                    _roverState = new NorthState(this);
                    break;
                case Direction.W:
                    _roverState = new WestState(this);
                    break;
                case Direction.S:
                    _roverState = new SouthState(this);
                    break;
                case Direction.E:
                    _roverState = new EastState(this);
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
            this._roverState.MoveForward();
        }

        public void MoveLeft()
        {
            this._roverState.MoveLeft();
        }

        public void MoveRight()
        {
            this._roverState.MoveRight();
        }
    }
}
