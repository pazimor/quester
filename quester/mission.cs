using System;
using System.Collections.Generic;
using System.Text;

namespace quester
{

    // attention tous les types de mission herites de mission du coup toutes les virtuals ici serront des override chez eux

    //note le rest des class qui herritent de celle-ci n'on que du text qu s'execute en fonction de celle-ci
    class mission
    {

        //WIP systeme de coordonee (initialement prevue pour un systeme de multy progression de quetes)
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
            //constructeur fill coortdonnee
            location = new coordinate(10000);
        }

        public virtual string type()
        {
            //need a return mais jamais utiliser
            return "chilling mission";
        }

        public virtual void nextStep()
        {
            //WIP prevue pour des etape plus complex
        }

        public int Selector(List<string> lst)
        {
            //meme selector que dans la class programe mais celui ci prend une list et ecrit la list par la meme occasion

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
            //appeller en cas d'ambuscade
        }

        public virtual void destination()
        {
            // appeler en cas d'arriver a destination
        }

        public virtual void finish()
        {
            // appeler en cas d'arriver final (apres avoir fait allee & retour)
        }

        public void going()
        {
            // petite animation pour l'aller + une fois fini trigger le retour
            const char destination = 'O';
            const string ship = "|-";

            for (int j = rand.Next(befor_space, space); j < space; j++)
            {
                //fait un affichage du vaiseau 
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
            // petite animation pour le retour + une fois fini trigger le final
            const char destination = 'O';
            const string ship = "-|";

            if (-befor_space >= 0)
                return;
            for (int j = rand.Next(-befor_space, 0); j <= 0 || befor_space == 0; j++)
            {
                //fait un affichage du vaiseau 
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
            //traveling est appelee de base par questProgress()
            //quand on decide de lancer la mission x (1, 2, 3, ...)
            Console.WriteLine("vous vous lancez dans votre mission.");
            
            //petite animation (avec facteur random)
            if (!travelBack)
                going();
            else
                goingBack();

            // si la petite animation s'arrete
            int ambu = rand.Next(0, 2);
            //alle fini
            if (befor_space == space)
            {
                destination();
                travelling();
            }
            //retour fini
            else if (befor_space == 0 && travelBack == true)
            {
                finish();
                travelling();
            }
            //ambuscade
            else if (ambu == 1)
            {
                this.ambush();
                travelling();
            }
            // arret dans une station (unstack la recursive + retour dans questProgress())
            else
            {
                Console.WriteLine("vous profitez de la station pour faire un arret dans votre mission.");
            }
            
        }
    }
}
