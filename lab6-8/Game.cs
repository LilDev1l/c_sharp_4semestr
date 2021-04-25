using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore
{
    [Serializable]
    public class Game
    {
        public string FullName { get; set; }
        public string SmallName { get; set; }
        public string Developer { get; set; }
        public string Image { get; set; }
        public Genre Genre { get; set; }
        public double Rating { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public SystemRequirements SystemRequirements { get; set; }

        public Game() { }


    }
}
