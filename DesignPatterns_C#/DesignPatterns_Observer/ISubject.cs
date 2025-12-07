using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns_Observer
{
    interface ISubject
    {
        public void registerObserver(IObserver observer);
        public void removeObserver(IObserver observer);
        public void notifyObservers();
    }
}
