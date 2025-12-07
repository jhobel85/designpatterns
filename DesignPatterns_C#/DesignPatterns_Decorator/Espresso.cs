using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns_Decorator
{
    public class Espresso : ABeverage
    {
        public Espresso()
        {
        }

        public override double Cost()
        {
            double priceEspresso = 1.99;
            return priceEspresso; // The price of the Espresso without any Condiments
        }
    }
}
