using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns_AbstractFactory
{

    class Bicycle : IVehicle
    {
        public Bicycle()
        {
            return;
        }

        public double getSpeed()
        {
            return 25;
        }
    }
}
