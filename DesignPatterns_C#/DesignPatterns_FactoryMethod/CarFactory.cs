using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns_AbstractFactory
{
    class CarFactory : IVehicleFactory
    {
        public IVehicle FactoryMethod()
        {
            return new Car();
        }
    }
}
