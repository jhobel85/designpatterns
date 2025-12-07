using System;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            Duck duck = new Duck(flyBehavior: new FlyWithRockets(), quarkBehavior: new Silent_Quark());
            duck.performFly();
            duck.performQuark();
            Console.ReadLine();
        }
    }
}
