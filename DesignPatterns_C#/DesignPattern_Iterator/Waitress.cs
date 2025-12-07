using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_Iterator
{
    class Waitress
    {
        List<IMenu> menus;

        public Waitress(List<IMenu> menus)
        {
            this.menus = menus;
        }

        public void PrintMenu()
        {
            foreach (IMenu menu in menus)
            {
                PrintMenu(menu.CreateIterator());
            }
        }

        private void PrintMenu(IIterator iterator)
        {
            while (iterator.HasNext())
            {
                MenuItem menuItem = (MenuItem)iterator.Next();
                Console.Write(menuItem.GetName() + ", ");
                Console.Write(menuItem.GetPrice() + " -- ");
                Console.WriteLine(menuItem.GetDescription());
            }
        }
    }
}
