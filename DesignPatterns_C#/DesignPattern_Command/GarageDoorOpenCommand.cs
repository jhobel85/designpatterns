using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_Command
{
    public class GarageDoorOpenCommand : ICommand
    {
        private GarageDoor _garageDoor;

        public GarageDoorOpenCommand(GarageDoor garageDoor)
        {
            this._garageDoor = garageDoor;
        }

        public void Execute()
        {
            _garageDoor.GarageDoorUp();
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
