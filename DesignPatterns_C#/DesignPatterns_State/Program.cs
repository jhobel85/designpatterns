using System;

namespace DesignPatterns_State
{
    class Program
    {
        static void Main(string[] args)
        {
            GumballMachine gumballMachine = new GumballMachine(5);
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
        }
    }
}
