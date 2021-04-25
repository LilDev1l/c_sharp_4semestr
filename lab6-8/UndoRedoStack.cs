using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GameStore
{
    class UndoRedoStack
    {
        public delegate void Command();
        private List<Command> Commands;
        private int pointer;

        public UndoRedoStack()
        {
            pointer = -1;
            Commands = new List<Command>();
        }

        public void AddAction(Command action)
        {
            pointer = Commands.Count;
            Commands.Add(action);
        }

        public void Redo()
        {
            if (pointer < Commands.Count - 1)
            {
                ++pointer;
                var action = Commands.ElementAt(pointer);
                action.Invoke();
            }
        }

        public void Undo()
        {
            if (pointer >  0)
            {
                pointer--;
                var action = Commands.ElementAt(pointer);
                action.Invoke();
            }
        }
    }
}
