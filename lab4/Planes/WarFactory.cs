using System;
using S2_Lab02.Models;
using S2_Lab02.Types;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2_Lab02.Planes
{
    class WarFactory : PlaneFactory
    {
        public override string CreateModel()
        {
            return new An26Model().ReturnModel();
        }

        public override string CreateType()
        {
            return new WarType().ReturnType();
        }
    }
}
