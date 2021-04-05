using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2_Lab02.Planes
{
    abstract class PlaneDecorator : Plane
    {
        public Plane plane;
        public PlaneDecorator(Plane plane, string str)
        {
            this.plane = plane;
            this.plane.Type = this.plane.Type + "(" + str + ")";
        }
    }
}
