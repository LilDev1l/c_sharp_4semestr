using S2_Lab02.Models;
using S2_Lab02.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2_Lab02.Planes
{
    class PassengerFactory : PlaneFactory
    {
        public override String CreateModel()
        {
            return new AirbusModel().ReturnModel();
        }

        public override String CreateType()
        {
            return new PassengerType().ReturnType();
        }
    }
}
