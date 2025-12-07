using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_TemplateMethod
{
    abstract class ACaffeineBeverage
    {
        // The Template method
        public void PrepareRecipe()
        {
            BoilWater();
            Brew();
            PourInCup();
            if (this.CustomerWantsCondiments())
            {
                AddCondiments();
            }
        }

        public abstract void Brew();

        public abstract void AddCondiments();

        public void BoilWater()
        {
            Console.WriteLine("Boiling Water");
        }

        public void PourInCup()
        {
            Console.WriteLine("Pouring into cup");
        }

        protected virtual bool CustomerWantsCondiments()
        {
            return true;
        }
    }
}
