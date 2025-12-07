using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns_Proxy
{
    class HasQuarterState : IState
    {
        GumballMachine gumballMachine;

        public HasQuarterState(GumballMachine gumballMachine)
        {
            this.gumballMachine = gumballMachine;
        }

        public void insertQuarter()
        {
            Console.WriteLine("You can’t insert another quarter");
        }

        public void ejectQuarter()
        {
            Console.WriteLine("Quarter returned");
            gumballMachine.setState(gumballMachine.GetNoQuarterState());
        }

        public void turnCrank()
        {
            Console.WriteLine("You turned...");
            gumballMachine.setState(gumballMachine.GetSoldState());
        }

        public void dispense()
        {
            Console.WriteLine("No gumball dispensed");
        }
    }
}
