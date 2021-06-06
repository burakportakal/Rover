using System;

namespace Rover
{
    public class Surface
    {
        public Surface()
        {

        }
        public Surface(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }
    }
    public interface IRover
    {
        void MoveLeft();
        void MoveRight();
        void MoveForward();

        void SetSurface(Surface surface);
        void SetPointAndDirection(int x, int y, string direction);
    }
    public enum Direction
    {
        N, S, E, W
    }
    public class Rover : IRover
    {
        private Surface surface;
        private Direction Direction;
        private int currentPointX;
        private int currentPointY;

        
        public Rover()
        {

        }
        public Rover(Surface surface)
        {
            this.surface = surface;
        }

        public void SetSurface(Surface surface)
        {
            this.surface = surface;
        }

        public void SetPointAndDirection(int x, int y, string direction)
        {
            Direction = Enum.Parse<Direction>(direction);
            this.currentPointX = x;
            this.currentPointY = y;
        }

        public override string ToString()
        {
            return $"{currentPointX} {currentPointY} {Direction}";
        }

        public void MoveForward()
        {
            if (currentPointX == 0 && Direction == Direction.W)
                return;
            if (currentPointY == 0 && Direction == Direction.S)
                return;
            if (currentPointX == surface.X && Direction == Direction.E)
                return;
            if (currentPointY == surface.Y && Direction == Direction.N)
                return;

            switch (Direction)
            {
                case Direction.N:
                    currentPointY += 1;
                    break;
                case Direction.W:
                    currentPointX -= 1;
                    break;
                case Direction.S:
                    currentPointY -= 1;
                    break;
                case Direction.E:
                    currentPointX += 1;
                    break;
            }
        }

        public void MoveLeft()
        {
            if (Direction == Direction.N)
            {
                Direction = Direction.W;
            }
            else if (Direction == Direction.W)
            {
                Direction = Direction.S;
            }
            else if (Direction == Direction.S)
            {
                Direction = Direction.E;
            }
            else if (Direction == Direction.E)
            {
                Direction = Direction.N;
            }
        }

        public void MoveRight()
        {
            if (Direction == Direction.N)
            {
                Direction = Direction.E;
            }
            else if (Direction == Direction.E)
            {
                Direction = Direction.S;
            }
            else if (Direction == Direction.S)
            {
                Direction = Direction.W;
            }
            else if (Direction == Direction.W)
            {
                Direction = Direction.N;
            }
        }
    }
}
