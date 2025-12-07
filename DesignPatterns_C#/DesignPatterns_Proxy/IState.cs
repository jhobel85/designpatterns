using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns_Proxy
{
    interface IState
    {
        public void insertQuarter();
        public void ejectQuarter();
        public void turnCrank();
        public void dispense();
    }
}
