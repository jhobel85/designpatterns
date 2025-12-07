using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_Iterator
{
    class DinerMenu : IMenu
    {
        static readonly int MAX_ITEMS = 6;
        int numberOfItems = 0;
        MenuItem[] menuItems;

        // constructor here
        public DinerMenu()
        {
            menuItems = new MenuItem[MAX_ITEMS];

            AddItem("Vegetarian BLT",
             "(Fakin’) Bacon with lettuce & tomato on whole wheat", true, 2.99);
            AddItem("BLT",
            "Bacon with lettuce & tomato on whole wheat", false, 2.99);
            AddItem("Soup of the day",
            "Soup of the day, with a side of potato salad", false, 3.29);
            AddItem("Hotdog",
            "A hot dog, with saurkraut, relish, onions, topped with cheese", false, 3.05);
        }

        // addItem here
        public void AddItem(String name, String description,
        Boolean vegetarian, double price)
        {
            if(numberOfItems >= MAX_ITEMS)
            {
                Console.WriteLine("Sorry, menu is full! Can't add item to menu");
            }
            menuItems[numberOfItems] = new MenuItem(name, description, vegetarian, price);
            numberOfItems++;
        }

        public IIterator CreateIterator()
        {
            return new DinerMenuIterator(menuItems);
        }
    }
}
