using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns_AbstractFactory
{
    class Car : IVehicle
    {
        public Car()
        {
            return;
        }


        public double getSpeed()
        {
            return 130.5;
        }
    }
}
