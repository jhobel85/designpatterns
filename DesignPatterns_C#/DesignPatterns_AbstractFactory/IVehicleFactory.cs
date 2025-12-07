using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns_AbstractFactory
{
    interface IVehicleFactory
    {
        public IVehicle FactoryMethod();
    }
}
