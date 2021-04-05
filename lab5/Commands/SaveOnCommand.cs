using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace S2_Lab02.Commands
{
    class SaveOnCommand : ICommand
    {
        private MainForm form;
        public SaveOnCommand(MainForm form)
        {
            this.form = form;
        }
        public void Execute()
        {
            try
            {
                var json = JsonConvert.SerializeObject(form.Planes);
                using var streamWriter = new StreamWriter(@"data/planes.json");
                streamWriter.Write(json);
                MessageBox.Show("Данные успешно сохранены.");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        public void Undo()
        {
        }
    }
}
