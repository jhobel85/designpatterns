using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns_Observer
{
    class Customer : IObserver
    {
        public void update(string product)
        {
            Console.WriteLine("The Product {0} is now available", product);
        }
    }
}
