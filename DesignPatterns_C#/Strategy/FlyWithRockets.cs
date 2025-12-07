using System;
using System.Collections.Generic;
using System.Text;

namespace Strategy
{
    class FlyWithRockets : AFlyBehavior
    {
        public FlyWithRockets()
        {

        }

        public override void fly()
        {
            Console.WriteLine("I fly with rockets");
        }
    }
}
