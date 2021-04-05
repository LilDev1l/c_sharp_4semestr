using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2_Lab02.Crew
{
    public abstract class CrewBuilder
    {
        public List<CrewMember> Crew { get; private set; }
        public void CreateCrew()
        {
            Crew = new List<CrewMember>();
        }
        public abstract void SetTypeCrew();
        public abstract void SetWorkExperienceCrew();
    }
}
