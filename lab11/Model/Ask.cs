using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace lab11.Model
{
    class Ask
    {
        public int IdSeller { get; set; }
        public int IdProduct { get; set; }
        public string NameSeller { get; set; }
        public string NameProduct { get; set; }
        public int Weight { get; set; }
        public int Price { get; set; }
    }
}
