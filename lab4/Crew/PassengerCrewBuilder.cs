using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2_Lab02.Crew
{
    class PassengerCrewBuilder : CrewBuilder
    {
        public override void SetTypeCrew()
        {
            int i = 0;
            Crew.Add(new CrewMember() { Name = "M" + i++, Position = "Пилот" });
            Crew.Add(new CrewMember() { Name = "M" + i++, Position = "Второй Пилот" });

            CrewMember crewMember = new CrewMember() { Name = "M" + i++, Position = "Стюардесса" };
            Crew.AddRange(new CrewMember[] { crewMember, crewMember.Clone() as CrewMember, crewMember.Clone() as CrewMember });
        }

        public override void SetWorkExperienceCrew()
        {
        }
    }
}
