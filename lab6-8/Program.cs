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
    }
}
