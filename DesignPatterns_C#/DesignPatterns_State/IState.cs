using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns_State
{
    interface IState
    {
        public void insertQuarter();
        public void ejectQuarter();
        public void turnCrank();
        public void dispense();
    }
}
