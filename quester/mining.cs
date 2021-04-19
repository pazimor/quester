using System;
using System.Collections.Generic;
using System.Text;


namespace quester
{
    class mining : mission
    {
        //structure de minerais (sert a la creation des asteroids)
        public struct minerals {

            public minerals(string n, int maxlazer, int minlazer, int maxexplo, int minexplo) 
            {
                name = n;
                maxLazer = maxlazer;
                minLazer = minlazer;
                maxExplo = maxexplo;
                minExplo = minexplo;
            }

            public string name;
            public int maxLazer;
            public int minLazer;
            public int maxExplo;
            public int minExplo;

        }

        List<string> ambushPirateLst = new List<string>();
        List<minerals> miningList = new List<minerals>();
        List<string> destinaionHowLst = new List<string>();

        public mining()
        {
            //creation des lists
            ambushPirateLst.Add("vous afrontez les pirates");
            ambushPirateLst.Add("vous faites un detour pour ne pas vous faire repérer");

            destinaionHowLst.Add("minage au laser");
            destinaionHowLst.Add("minage a l'explosif");

            //Values are randoms
            miningList.Add(new minerals("Opals du vide", 10, 8, 9, 5));
            miningList.Add(new minerals("Diamant basse temperature", 12, 9, 11, 5));
            miningList.Add(new minerals("Alexandrite", 15, 8, 20, 15));
            miningList.Add(new minerals("Platinium", 10, 8, 15, 10));
            miningList.Add(new minerals("Thorium", 10, 8, 10, 8));
            miningList.Add(new minerals("Or", 30, 15, 10, 5));


        }

        public override string type()
        {
            return "mission de minage";
        }

        public override void nextStep()
        {

        }

        public override void ambush()
        {
            //embuscade story
            Console.WriteLine("lors de votre voyage vous rencontrez des pirates.");
            Console.WriteLine("que faite vous ??");
            if (base.Selector(ambushPirateLst) == 1)
            {
                Console.WriteLine("apres de multiples péripéties :");
                if (base.rand.Next(0, 4) == 0)
                {
                    Console.WriteLine("vous n'avez pas d'autre choix que de vous echapper.");
                }
                else
                {
                    Console.WriteLine("vous parvenez a abattre les pirates !!");
                }
            }
            else
            {
                Console.WriteLine("vous rebroussez chemain et arrivez a vous en sortire sans encombres.");
            }

        }

        public void randomizeAsteroids(int i, bool explo)
        {
            //random chaques asteroides
            minerals current = miningList[base.rand.Next(0, miningList.Count)];
            Console.WriteLine("asteroid " + (i + 1) + ") vous avez recuperer : " + ((explo) ? base.rand.Next(current.minExplo, current.maxExplo) : base.rand.Next(current.minLazer, current.maxLazer)) + " fragment de : " + current.name);
        }
        
        public override void destination()
        {
            //mining session
            Console.WriteLine("vous arrivez a destination.");
            //generations d'asteroides contenant des resources
            int nbAsteroids = base.rand.Next(5, 10);
            Console.WriteLine("devant vous ce trouve " + nbAsteroids + " asteroids.");
            Console.WriteLine("comment voulez-vous miner ??");
            
            //ici sont generer les materiaux recupere des asteroides en fonction des methodes d'extractions
            if (base.Selector(destinaionHowLst) == 1)
            {
                for(int i = 0; i < nbAsteroids; i++)
                {
                    randomizeAsteroids(i, false);
                }
            }
            else
            {
                for (int i = 0; i < nbAsteroids; i++)
                {
                    randomizeAsteroids(i, true);
                }
            }
            Console.WriteLine("vous avez tout miner");
            Console.WriteLine("vous retournez sur vos pas pour vendre votre marchadise aux plus offrant");
        }
    }
}
