using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rover
{
    public enum Command
    {
        L,
        R,
        M
    }

    public class OperationCenter
    {
        private IRover rover;
        public OperationCenter()
        {
        }
        public OperationCenter(IRover rover)
        {
            this.rover = rover;
        }

        public void SetRover(IRover rover)
        {
            this.rover = rover;
        }

        public void ExecuteCommand(ConsoleCommand command)
        {
            command.Execute(rover);
        }

        public string GetLastSpot()
        {
            return this.rover.ToString();
        }


    }
}
