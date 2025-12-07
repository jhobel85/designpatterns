using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_Command
{
    public class NoCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Kein Befehl wurde ausgeführt");
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
