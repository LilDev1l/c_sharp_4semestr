using S2_Lab02.Planes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace S2_Lab02
{
    public partial class GenerationForm : Form
    {
        private MainForm form;
        public GenerationForm(MainForm mainForm)
        {
            InitializeComponent();
            form = mainForm;

            Closed += (_, _) => { mainForm.Enabled = true; };
        }

        private void GenerationButton_Click(object sender, EventArgs e)
        {
            int quantityPlanes = (int)QuantityPlanesNumricUpDown.Value;
            if (AirTypeCargo.Checked)
                for (int i = 0; i < quantityPlanes; i++)
                {
                    form.Planes.Add(new Plane(new CargoFactory(), i + 1));
                }
            else if (AirTypePassenger.Checked)
                for (int i = 0; i < quantityPlanes; i++)
                {
                    form.Planes.Add(new Plane(new PassengerFactory(), i + 1));
                }
            else if (AirTypeWar.Checked)
                for (int i = 0; i < quantityPlanes; i++)
                {
                    form.Planes.Add(new Plane(new WarFactory(), i + 1));
                }
            form.GenerateNewDataView();
        }
    }
}
