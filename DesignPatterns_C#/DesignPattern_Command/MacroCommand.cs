using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_Command
{
    class MacroCommand : ICommand
    {
        ICommand[] _commands;

        public MacroCommand(ICommand[] commands)
        {
            _commands = commands;
        }
        public void Execute()
        {
            foreach(ICommand cmd in _commands)
            {
                cmd.Execute();
            }
        }

        public void Undo()
        {
            foreach(ICommand cmd in _commands)
            {
                cmd.Undo();
            }
        }
    }
}
