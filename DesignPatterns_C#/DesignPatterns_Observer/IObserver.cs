using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns_Observer
{
    interface IObserver
    {
        public void update(string product);
    }
}
