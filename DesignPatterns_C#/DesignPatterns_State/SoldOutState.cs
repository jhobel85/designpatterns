using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns_State
{
    class SoldOutState : IState
    {
        GumballMachine gumballMachine;

        public SoldOutState(GumballMachine gumballMachine)
        {
            this.gumballMachine = gumballMachine;
        }

        public void dispense()
        {
            Console.WriteLine("There are no more gumballs left");
        }

        public void ejectQuarter()
        {
            Console.WriteLine("There is no quarter instered");
        }

        public void insertQuarter()
        {
            Console.WriteLine("You can't insert a quarter right now");
        }

        public void turnCrank()
        {
            Console.WriteLine("There is no quarter instered");
        }
    }
}
