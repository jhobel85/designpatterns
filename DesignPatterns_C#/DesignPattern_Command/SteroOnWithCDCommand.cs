using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_Command
{
    public class StereoOnWithCDCommand : ICommand
    {
        Stereo _stereo;
        public StereoOnWithCDCommand(Stereo stereo)
        {
            this._stereo = stereo;
        }
        public void Execute()
        {
            _stereo.StereoOn();
            _stereo.StereoSetCD();
            _stereo.StereoSetVolume(11);
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
