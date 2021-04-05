using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2_Lab02.Commands
{
    class ClearOnCommand : ICommand
    {
        private MainForm form;
        public ClearOnCommand(MainForm form)
        {
            this.form = form;
        }
        public void Execute()
        {
            form.Planes.Clear();
            form._crew.Clear();
            form._planesIdList.Clear();
            form.DataView.Nodes["Airport"].Nodes.Clear();
            form.StatusItemObjectsSetAmountLabel.Text = "0";
        }

        public void Undo()
        {
        }
    }
}
