namespace Rover
{
    public abstract class CommandBase
    {
        public CommandBase(object inputCommand)
        {
            InputCommand = inputCommand;
        }
        public object InputCommand { get; set; }
    }
}
