using System;

namespace DesignPatterns_Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            Pizza pizza = new PizzaBuilder()
                .AddHam()
                .AddOnions()
                .AddTomatoes()
                .Build();

            foreach(string s in pizza.getIngredients())
            {
                Console.WriteLine(s);
            }
            Console.ReadLine();

        }
    }
}
