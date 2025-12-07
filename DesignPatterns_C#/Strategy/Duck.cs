using System;
using System.Collections.Generic;
using System.Text;

namespace Strategy
{
    class Duck
    {
        private AFlyBehavior m_flyBehavior;
        private AQuarkBehavior m_quarkBehavior;

        public Duck(AFlyBehavior flyBehavior, AQuarkBehavior quarkBehavior)
        {
            m_flyBehavior = flyBehavior;
            m_quarkBehavior = quarkBehavior;
        }

        public void performQuark()
        {
            m_quarkBehavior.quark();
        }

        public void performFly()
        {
            m_flyBehavior.fly();
        }
    }
}
