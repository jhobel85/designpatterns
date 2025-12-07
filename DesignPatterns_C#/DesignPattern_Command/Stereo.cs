using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_Command
{
    public class Stereo
    {
        String _stero;

        public Stereo(String stero)
        {
            _stero = stero;
        }

        public void StereoOn()
        {
            Console.WriteLine(_stero + " Stereo wird angeschaltet");
        }

        public void StereoOff()
        {
            Console.WriteLine(_stero + " Stereo wird ausgeschaltet");
        }

        public void StereoSetCD()
        {
            Console.WriteLine(_stero + " Stereo setz auf CD");
        }

        public void StereoSetDvD()
        {
            Console.WriteLine(_stero + " Stereo setz auf DVD");
        }

        public void StereoSetRadio()
        {
            Console.WriteLine(_stero + " Stereo setz auf Radio");
        }

        public void StereoSetVolume(int volume)
        {
            Console.WriteLine(_stero + " Stereo setz die Lautstärke auf {0}", volume);
        }
    }
}
