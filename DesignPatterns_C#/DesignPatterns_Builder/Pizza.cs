using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns_Builder
{
    class Pizza
    {
        private List<String> _Ingredients = new List<string>();

        public Pizza()
        {
            return;
        }

        public Pizza AddIngredient(string ingredient)
        {
            _Ingredients.Add(ingredient);
            return this;
        }

        public List<string> getIngredients()
        {
            return _Ingredients;
        }
    }
}
