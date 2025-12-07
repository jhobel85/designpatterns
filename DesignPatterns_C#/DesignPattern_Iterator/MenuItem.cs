using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_Iterator
{
    public class MenuItem
    {
        private String name;
        private String description;
        private Boolean vegetarian;
        private double price;

        public MenuItem(String name,
        String description,
        Boolean vegetarian,
        double price)
        {
            this.name = name;
            this.description = description;
            this.vegetarian = vegetarian;
            this.price = price;
        }

        public String GetName()
        {
            return name;
        }

        public String GetDescription()
        {
            return description;
        }

        public double GetPrice()
        {
            return price;
        }

        public Boolean IsVegetarian()
        {
            return vegetarian;
        }
    }
}
