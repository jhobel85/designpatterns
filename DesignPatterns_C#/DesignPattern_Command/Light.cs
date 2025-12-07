using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_Command
{
    public class Light
    {
        String _light;

        public Light(String light)
        {
            _light = light;
        }

        public void LightOn()
        {
            Console.WriteLine(_light + "-Licht An");
        }

        public void LightOff()
        {
            Console.WriteLine(_light + "-Licht Aus");
        }
    }
}
