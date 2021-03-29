using System;
using S2_Lab02.Models;
using S2_Lab02.Types;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2_Lab02.Planes
{
    class CargoFactory : PlaneFactory
    {
        public override string CreateModel()
        {
            return new MD_11Model().ReturnModel();
        }

        public override string CreateType()
        {
            return new CargoType().ReturnType();
        }
    }
}
