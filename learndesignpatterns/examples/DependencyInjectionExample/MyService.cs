using System;

namespace DependencyInjectionExample
{
    public class MyService : IMyService
    {
        public void DoSomething()
        {
            Console.WriteLine("MyService is doing something.");
        }
    }
}