using System;

namespace DesignPatterns_Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            ABeverage espresso = new Espresso();
            Console.WriteLine(espresso.Cost());

            ABeverage houseBlendWithMocha = new HouseBlend();
            houseBlendWithMocha = new Mocha(houseBlendWithMocha);
            Console.WriteLine(houseBlendWithMocha.Cost());

            ABeverage houseBlendWithDoubleMochaAndWhip = new HouseBlend();
            houseBlendWithDoubleMochaAndWhip = new Mocha(new Mocha(new Whip(houseBlendWithDoubleMochaAndWhip)));
            Console.WriteLine(houseBlendWithDoubleMochaAndWhip.Cost());

            Console.ReadLine();
            
        }
    }
}
