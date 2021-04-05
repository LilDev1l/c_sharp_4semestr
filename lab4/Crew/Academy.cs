using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2_Lab02.Crew
{
    class Academy
    {
        public List<CrewMember> ReturnCrew(CrewBuilder crewBuilder)
        {
            crewBuilder.CreateCrew();
            crewBuilder.SetTypeCrew();
            crewBuilder.SetWorkExperienceCrew();
            return crewBuilder.Crew;
        }
    }
}
