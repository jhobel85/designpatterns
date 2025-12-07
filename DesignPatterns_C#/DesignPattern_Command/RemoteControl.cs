using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_Command
{
    public class RemoteControl
    {
        ICommand[] _onCommands;
        ICommand[] _offCommands;
        ICommand undoCommand;

        public RemoteControl()
        {
            _onCommands = new ICommand[7];
            _offCommands = new ICommand[7];
            ICommand noCommand = new NoCommand();
            for (int i = 0; i < 7; i++)
            {
                _onCommands[i] = noCommand;
                _offCommands[i] = noCommand;
            }
            undoCommand = noCommand;
        }

        public void setCommand(int slot, ICommand onCommand, ICommand offCommand)
        {
            _onCommands[slot] = onCommand;
            _offCommands[slot] = offCommand;
        }
        public void onButtonWasPushed(int slot)
        {
            _onCommands[slot].Execute();
            undoCommand = _onCommands[slot];
        }
        public void offButtonWasPushed(int slot)
        {
            _offCommands[slot].Execute();
            undoCommand = _offCommands[slot];
        }

        public void undoButtonWasPushed()
        {
            undoCommand.Undo();
        }


        public String toString()
        {
            String remoteString = "";
            remoteString += "\n------ Remote Control------ -\n";
            for (int i = 0; i < _onCommands.Length; i++)
            {
                remoteString += "Slot: " + i + _onCommands[i].GetType().Name + " " + _offCommands[i].GetType().Name + "\n";
            }
            return remoteString;
        }
    }
}
