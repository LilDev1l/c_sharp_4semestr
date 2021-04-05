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
    class ReadOnCommand : ICommand
    {
        private MainForm form;
        public ReadOnCommand(MainForm form)
        {
            this.form = form;
        }
        public void Execute()
        {
            try
            {
                using var streamReader = new StreamReader(@"data/planes.json");
                var json = streamReader.ReadToEnd();
                form.Planes = JsonConvert.DeserializeObject<List<Plane>>(json);
                MessageBox.Show("Данные успешно считаны.");
                form.GenerateNewDataView();
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
