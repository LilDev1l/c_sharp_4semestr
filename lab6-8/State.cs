using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore
{
    class State
    {
        private static State state;
        private static readonly object locker = new object();
        public Languege Languege { get; set; }
        public ThemeType Theme { get; set; }

        private State()
        {
        }
        public static State GetState()
        {
            if (state == null)
            {
                lock (locker)
                {
                    if (state == null)
                    {
                        state = new State();
                    }
                }
            }
            return state;
        }
    }
}
