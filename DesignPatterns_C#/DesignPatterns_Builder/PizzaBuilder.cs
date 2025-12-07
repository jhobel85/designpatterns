using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns_Builder
{
    class PizzaBuilder
    {
        private Pizza _pizza = new Pizza();
        public PizzaBuilder()
        {
            this.Reset();
        }

        public void Reset()
        {
            this._pizza = new Pizza();
        }

        public PizzaBuilder AddOnions()
        {
            this._pizza.AddIngredient("Onion");
            return this;
        }
        public PizzaBuilder AddHam()
        {
            this._pizza.AddIngredient("Ham");
            return this;
        }
        public PizzaBuilder AddTomatoes()
        {
            this._pizza.AddIngredient("Toamatoes");
            return this;
        }

        public Pizza Build()
        {
            return _pizza;
        }
    }
}
