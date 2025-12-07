using System;

namespace DesignPatterns_Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer();
            Product product = new Product("apples");

            product.registerObserver(customer);
            product.notifyObservers();

            Console.ReadKey();
        }
    }
}
