using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns_Proxy
{
    class GumballMonitor
    {
        GumballMachine machine;
        public GumballMonitor(GumballMachine machine)
        {
            this.machine = machine;
        }
        public void report()
        {
            Console.WriteLine("Gumball Machine: " + machine.GetLocation());
            Console.WriteLine("Gurrent inventory: " + machine.GetCount() + " gumballs");
            Console.WriteLine("Gurrent state: " + machine.GetState());
        }
    }
}
