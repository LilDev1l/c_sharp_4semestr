using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2_Lab02.Commands
{
    class MultiPult
    {
        Dictionary<string, ICommand> commands;

        public MultiPult()
        {
            commands = new Dictionary<string, ICommand>();
        }

        public void SetCommand(string strCommand, ICommand command)
        {
            commands[strCommand] = command;
        }

        public void PressButton(string strCommand)
        {
            if (commands[strCommand] != null)
                commands[strCommand].Execute();
        }
        public void PressUndoButton()
        {
        }
    }
}
