namespace Rover
{
    public interface IRover
    {
        void MoveLeft();
        void MoveRight();
        void MoveForward();

        void SetSurface(Surface surface);
        void SetPointAndDirection(int x, int y, string direction);
    }
}
