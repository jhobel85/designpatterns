using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns_Decorator
{
    public class Mocha : ACondimentDecorator
    {
        private ABeverage _beverage;

        public Mocha(ABeverage beverage)
        {
            this._beverage = beverage;
        }

        public override double Cost()
        {
            double priceOfMocha = 0.20;
            return _beverage.Cost() + priceOfMocha;
        }
    }
}
