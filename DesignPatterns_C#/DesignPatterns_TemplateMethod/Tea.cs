using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_TemplateMethod
{
    class Tea : ACaffeineBeverage
    {
        public override void Brew()
        {
            Console.WriteLine("Steeping the tea");
        }

        public override void AddCondiments()
        {
            Console.WriteLine("Adding Lemon");
        }
    }
}
