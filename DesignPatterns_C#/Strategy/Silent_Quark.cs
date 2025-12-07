using System;
using System.Collections.Generic;
using System.Text;

namespace Strategy
{
    class Silent_Quark : AQuarkBehavior
    {
        public Silent_Quark()
        {

        }

        public override void quark()
        {
            Console.WriteLine("Silence");
        }
    }
}
