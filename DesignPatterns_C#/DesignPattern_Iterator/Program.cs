using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_Iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            PancakeHouseMenu pancakeHouseMenu = new PancakeHouseMenu();
            DinerMenu dinerMenu = new DinerMenu();
            List<IMenu> menus = new List<IMenu>();
            menus.Add(dinerMenu);
            menus.Add(pancakeHouseMenu);
            Waitress waitress = new Waitress(menus);
            waitress.PrintMenu();
        }
    }
}
