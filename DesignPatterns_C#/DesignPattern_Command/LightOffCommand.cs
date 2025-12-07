using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_Command
{
    public class LightOffCommand : ICommand
    {
        Light _light;
        public LightOffCommand(Light light)
        {
            this._light = light;
        }

        public void Execute()
        {
            _light.LightOff();
        }

        public void Undo()
        {
            _light.LightOn();
        }
    }
}
