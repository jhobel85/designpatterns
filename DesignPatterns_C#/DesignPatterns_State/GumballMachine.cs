using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns_State
{
    class GumballMachine
    {
        IState soldOutState;
        IState noQuarterState;
        IState hasQuarterState;
        IState soldState;
        IState state;

        int count = 0;

        public GumballMachine(int numberGumballs)
        {
            soldOutState = new SoldOutState(this);
            noQuarterState = new NoQuarterState(this);
            hasQuarterState = new HasQuarterState(this);
            soldState = new SoldState(this);

            state = soldOutState;
            this.count = numberGumballs;

            if (numberGumballs > 0)
            {
                state = noQuarterState;
            }
        }

        public void insertQuarter()
        {
            state.insertQuarter();
        }

        public void ejectQuarter()
        {
            state.ejectQuarter();
        }

        public void turnCrank()
        {
            state.turnCrank();
            state.dispense();
        }

        public void setState(IState state)
        {
            this.state = state;
        }

        public IState GetState()
        {
            return this.state;
        }

        public void releaseBall()
        {
            Console.WriteLine("A gumball comes rolling out the slot...");
            if (count != 0)
            {
                count = count - 1;
            }
        }

        public IState GetNoQuarterState()
        {
            return noQuarterState;
        }

        public IState GetHasQuarterState()
        {
            return hasQuarterState;
        }

        public IState GetSoldState()
        {
            return soldState;
        }

        public IState GetSoldOutState()
        {
            return soldOutState;
        }

        public int GetCount()
        {
            return count;
        }
    }
}
