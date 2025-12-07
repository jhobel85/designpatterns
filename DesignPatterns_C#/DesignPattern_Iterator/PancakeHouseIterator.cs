using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_Iterator
{
    class PancakeHouseIterator : IIterator
    {
        ArrayList items;
        int position = 0;

        public PancakeHouseIterator(ArrayList items)
        {
            this.items = items;
        }

        public Object Next()
        {
            MenuItem menuItem = (MenuItem)items[position];
            position = position + 1;
            return menuItem;
        }
        public Boolean HasNext()
        {
            if (position >= items.Count || items[position] == null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}
