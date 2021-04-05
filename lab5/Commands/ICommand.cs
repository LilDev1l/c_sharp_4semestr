using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2_Lab02.Commands
{
    interface ICommand
    {
        void Execute();
        void Undo();
    }
}
