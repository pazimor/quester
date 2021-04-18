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
        public int space = 26;
        public int befor_space = 0;
        public bool travelBack = false;
        public bool isFinish = false;

        public Random rand = new Random();

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
            int number = lst.Count; //can't be greater than 9
            int i = 0;
            foreach (string a in lst)
            {
                i += 1;
                Console.WriteLine("\t" + i + ") " + a);
            }
            char ret = Console.ReadLine()[0];
            return (ret > '0' && ret <= '0' + number) ? ret - '0' : Selector(lst);
        }

        public virtual void ambush()
        {
            
        }

        public virtual void destination()
        {

        }

        public virtual void finish()
        {

        }

        public void going()
        {
            const char destination = 'O';
            const string ship = "|-";

            for (int j = rand.Next(befor_space, space); j < space; j++)
            {
                for (int i = 0; i <= space; i++)
                {
                    if (i == befor_space)
                        Console.Write(ship);
                    else if (i == space)
                        Console.Write(destination);
                    else
                        Console.Write(' ');
                }
                Console.Write('\r');
                befor_space += 1;
                System.Threading.Thread.Sleep(500);
            }
            if (befor_space == space)
                travelBack = true;
            Console.Write('\n');
        }

        public void goingBack()
        {
            const char destination = 'O';
            const string ship = "-|";

            if (-befor_space >= 0)
                return;
            for (int j = rand.Next(-befor_space, 0); j <= 0 || befor_space == 0; j++)
            {
                for (int i = 0; i <= space; i++)
                {
                    if (i == befor_space)
                        Console.Write(ship);
                    else if (i == space)
                        Console.Write(destination);
                    else
                        Console.Write(' ');
                }
                Console.Write('\r');
                befor_space -= 1;
                System.Threading.Thread.Sleep(500);
            }
            if (befor_space <= 0)
                isFinish = true;
            Console.Write('\n');


        }

        public void travelling()
        {
            Console.WriteLine("vous vous lancez dans votre mission.");
            
            if (!travelBack)
                going();
            else
                goingBack();

            int ambu = rand.Next(0, 2);
            if (befor_space == space)
            {
                destination();
                travelling();
            }
            else if (befor_space == 0 && travelBack == true)
            {
                finish();
                travelling();
            }
            else if (ambu == 1)
            {
                this.ambush();
                travelling();
            }
            else
            {
                Console.WriteLine("vous profitez de la station pour faire un arret dans votre mission.");
            }
            
        }
    }
}
