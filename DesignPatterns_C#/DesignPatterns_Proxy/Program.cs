using System;

namespace DesignPatterns_Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            String location = "Amberg";
            GumballMachine gumballMachine = new GumballMachine(location, 5);
            GumballMonitor monitor = new GumballMonitor(gumballMachine);
            Console.WriteLine(gumballMachine);
            gumballMachine.insertQuarter();
            gumballMachine.turnCrank();
            Console.WriteLine(gumballMachine);
            gumballMachine.insertQuarter();
            gumballMachine.ejectQuarter();
            gumballMachine.turnCrank();
            Console.WriteLine(gumballMachine);
            gumballMachine.insertQuarter();
            gumballMachine.turnCrank();
            gumballMachine.insertQuarter();
            gumballMachine.turnCrank();
            gumballMachine.ejectQuarter();
            Console.WriteLine(gumballMachine);
            gumballMachine.insertQuarter();
            gumballMachine.insertQuarter();
            gumballMachine.turnCrank();
            gumballMachine.insertQuarter();
            gumballMachine.turnCrank();
            gumballMachine.insertQuarter();
            gumballMachine.turnCrank();
            Console.WriteLine(gumballMachine);

            monitor.report();
        }
    }
}
