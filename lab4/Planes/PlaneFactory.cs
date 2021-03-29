using S2_Lab02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2_Lab02.Planes
{
    public abstract class PlaneFactory
    {
        public abstract String CreateModel();
        public abstract String CreateType();
    }
}
