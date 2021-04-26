using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramStore
{
    [Serializable]
    public class Program
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public Category Category { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
 

        public override bool Equals(object obj)
        {
            if (obj is Program)
            {
                Program program = (Program)obj;
                if (program.Name == this.Name)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        public override int GetHashCode()
        {
            int hashCode = 1565895131;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            return hashCode;
        }
    }
}
