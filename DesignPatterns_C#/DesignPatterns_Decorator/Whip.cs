using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns_Decorator
{
    public class Whip : ACondimentDecorator
    {
        private ABeverage _beverage;

        public Whip(ABeverage beverage)
        {
            this._beverage = beverage;
        }

        public override double Cost()
        {
            double priceOfWhip = 0.10;
            return _beverage.Cost() + priceOfWhip;
        }
    }
}
