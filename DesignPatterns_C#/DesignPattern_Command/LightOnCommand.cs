using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_Command
{
    public class LightOnCommand : ICommand
    {
        private Light _light;

        public LightOnCommand(Light light)
        {
            this._light = light;
        }

        public void Execute()
        {
            _light.LightOn();
        }

        public void Undo()
        {
            _light.LightOff();
        }
    }
}
