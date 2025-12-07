using System;
using System.Collections.Generic;
using System.Text;

namespace Strategy
{
    class Quark : AQuarkBehavior
    {
        public Quark()
        {

        }

        public override void quark()
        {
            Console.WriteLine("Quark");
        }
    }
}
