using System;
using System.Collections.Generic;
using System.Text;

namespace Strategy
{
    class FlyWithWings : AFlyBehavior
    {
        public FlyWithWings()
        {

        }

        public override void fly()
        {
            Console.WriteLine("I fly with wings");
        }
    }
}
