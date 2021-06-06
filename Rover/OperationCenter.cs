namespace Rover
{ 
    public class OperationCenter
    {
        private IRover _rover;
        public OperationCenter() {}
        public OperationCenter(IRover rover)
        {
            _rover = rover;
        }

        public void SetRover(IRover rover)
        {
            _rover = rover;
        }

        public void ExecuteCommand(IConsoleCommand command)
        {
            command.Execute(_rover);
        }

        public string GetLastSpot()
        {
            return _rover.ToString();
        }
    }
}
