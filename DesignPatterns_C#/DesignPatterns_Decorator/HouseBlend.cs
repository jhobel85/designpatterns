using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns_Decorator
{
    public class HouseBlend : ABeverage
    {
        public HouseBlend()
        {
        }

        public override double Cost()
        {
            double priceHouseBlend = 1.89;
            return priceHouseBlend; // The price of the Espresso without any Condiments
        }
    }
}
