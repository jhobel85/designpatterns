using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_Command
{
    public class GarageDoor
    {
        String _garageDoor;

        public GarageDoor(String garageDoor)
        {
            _garageDoor = garageDoor;
        }

        public void GarageDoorUp()
        {
            Console.WriteLine(_garageDoor + " Garagen Tür öffnet sich");
        }

        public void GarageDoorDown()
        {
            Console.WriteLine(_garageDoor + " Garagen Tür schließt sich");
        }

        public void GarageDoorstop()
        {
            Console.WriteLine(_garageDoor + " Garagen Tür stoppt");
        }

        public void GarageDoorLightOn()
        {
            Console.WriteLine(_garageDoor + " Garagen Tür Licht an");
        }

        public void GarageDoorLightOff()
        {
            Console.WriteLine(_garageDoor + " Garagen Tür Licht aus");
        }
    }
}
