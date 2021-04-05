using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2_Lab02.Crew
{
    class WarCrewBuilder : CrewBuilder
    {
        public override void SetTypeCrew()
        {
            Crew.Add(new CrewMember() { Name = "M" + 0, Position = "Пилот" });
        }

        public override void SetWorkExperienceCrew()
        {
        }
    }
}
