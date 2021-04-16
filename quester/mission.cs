using System;
using System.Collections.Generic;
using System.Text;

namespace quester
{
    class mission
    {

        public struct coordinate
        {
            public coordinate(int minmax)
            {
                Random rnd = new Random();
                x = rnd.Next(-minmax, minmax);
                y = rnd.Next(-minmax, minmax);
                z = rnd.Next(-minmax, minmax);
            }
            coordinate(int x, int y, int z) { this.x = x; this.y = y; this.z = z; }
            int x;
            int y;
            int z;
        }

        public coordinate location;

        public mission()
        {
            location = new coordinate(10000);
        }

        public virtual string type()
        {
            return "chilling mission";
        }

        public virtual void nextStep()
        {

        }

        public int Selector(List<string> lst)
        {
            return 0;
        }

        public virtual void ambush()
        {

        }

        public virtual void destination()
        {

        }

        public void travelling()
        {
            // make progress
            string test = "|-.....................O";
        }
    }
}
