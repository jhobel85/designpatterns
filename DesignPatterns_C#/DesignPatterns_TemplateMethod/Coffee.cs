using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_TemplateMethod
{
    class Coffee : ACaffeineBeverage
    {
        public override void Brew()
        {
            Console.WriteLine("Dripping Coffee through filter");
        }

        public override void AddCondiments()
        {
            Console.WriteLine("Adding Sugar and Milk");
        }

        protected override bool CustomerWantsCondiments()
        {
            String answer = getUserInput();
            if (answer.ToLower().StartsWith("y"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private String getUserInput()
        {
            String answer = null;
            Console.WriteLine("Would you like milk and sugar with your coffee(y / n) ? ");
            answer = Console.ReadLine();
           
            if (answer == null)
            {
                return "n";
            }
            return answer;
        }
    }
}
