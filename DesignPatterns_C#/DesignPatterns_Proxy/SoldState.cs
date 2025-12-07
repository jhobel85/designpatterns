using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns_Proxy
{
    class SoldState : IState
    {
        GumballMachine gumballMachine;
        public SoldState(GumballMachine gumballMachine)
        {
            this.gumballMachine = gumballMachine;
        }

        public void insertQuarter()
        {
            Console.WriteLine("Please wait, we’re already giving you a gumball");
        }

        public void ejectQuarter()
        {
            Console.WriteLine("Sorry, you already turned the crank");
        }

        public void turnCrank()
        {
            Console.WriteLine("Turning twice doesn’t get you another gumball!");
        }

        public void dispense()
        {
            gumballMachine.releaseBall();
            if (gumballMachine.GetCount() > 0)
            {
                gumballMachine.setState(gumballMachine.GetNoQuarterState());
            }
            else
            {
                Console.WriteLine("Oops, out of gumballs!");
                gumballMachine.setState(gumballMachine.GetSoldOutState());
            }
        }
    }
}
