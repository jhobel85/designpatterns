using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns_AbstractFactory
{
    class BicycleFactory : IVehicleFactory
    {
        public IVehicle FactoryMethod()
        {
            return new Bicycle();
        }
    }
}
