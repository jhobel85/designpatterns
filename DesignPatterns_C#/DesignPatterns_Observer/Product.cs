using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns_Observer
{
    class Product : ISubject
    {
        private List<IObserver> _observers;
        private string _nameOfTheProduct;
        public Product(string nameOfTheProduct)
        {
            _nameOfTheProduct = nameOfTheProduct;
            _observers = new List<IObserver>();
        }
      
        public void registerObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void removeObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void notifyObservers()
        {
            foreach(IObserver o in _observers)
            {
                o.update(this._nameOfTheProduct);
            }
        }
    }
}
