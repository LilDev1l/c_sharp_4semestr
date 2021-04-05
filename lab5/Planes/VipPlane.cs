using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2_Lab02.Planes
{
    class VipPlane : PlaneDecorator
    {
        public VipPlane(Plane plane) : base(plane, "VIP") { }
    }
}
