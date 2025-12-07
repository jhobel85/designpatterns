using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns_State
{
    class NoQuarterState : IState
    {
        GumballMachine gumballMachine;
        public NoQuarterState(GumballMachine gumballMachine)
        {
            this.gumballMachine = gumballMachine;
        }
        public void insertQuarter()
        {
            Console.WriteLine("You inserted a quarter");
            gumballMachine.setState(gumballMachine.GetHasQuarterState());
        }
        public void ejectQuarter()
        {
            Console.WriteLine("You haven’t inserted a quarter");
        }
        public void turnCrank()
        {
            Console.WriteLine("You turned, but there’s no quarter");
        }
        public void dispense()
        {
            Console.WriteLine("You need to pay first");
        }
    }
}
