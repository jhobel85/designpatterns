using System;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjectionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IMyService, MyService>()
                .AddTransient<MyClass>()
                .BuildServiceProvider();

            var myClass = serviceProvider.GetService<MyClass>();
            myClass.DoSomething();

            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }
    }
}