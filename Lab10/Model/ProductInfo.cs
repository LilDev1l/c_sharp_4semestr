using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace lab10.Model
{
    class ProductInfo
    {
        public int Id { get; set; }
        public int IconId { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Qty { get; set; }
        public BitmapFrame Photo { get; set; }
    }
}
