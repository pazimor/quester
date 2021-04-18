using System;
using System.Collections.Generic;
using System.Text;

namespace quester
{
    class bountyHunter : mission
    {
        List<string> ambushPirateLst = new List<string>();
        List<string> destinationWantedLst = new List<string>();
        List<string> destinationoutpostLst = new List<string>();

        public bountyHunter()
        {
            ambushPirateLst.Add("vous afrontez les pirates");
            ambushPirateLst.Add("vous faites un detour pour ne pas vous faire repérer");

            destinationWantedLst.Add("vous passez par le champs d'asteroids du system pour mettre a l'epreuve les talents de pilotage de votre cible.");
            destinationWantedLst.Add("vous lui faite face et lui tirez dessus.");

            destinationoutpostLst.Add("vous tentez sabotez le systeme de securitee de l'avant-post.");
            destinationoutpostLst.Add("vous recherchez de loin une faille dans l'avant post pour pouvoire tout faire exploser.");
        }

        public override string type()
        {
            return "mission de chasseur de prime";
        }

        public override void nextStep()
        {

        }

        public override void ambush()
        {
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

        public override void destination()
        {
            //wanted or outpost
            Console.WriteLine("vous arrivez a destination.");
            int nbAsteroids = base.rand.Next(0, 2);

            if (base.rand.Next(0, 2) == 1)
            {
                Console.WriteLine("en face de vous ce dresse votre adversaire.");
                Console.WriteLine("vous allez devoir l'affronter: comment compter vous faire ?");
                if (base.Selector(destinationWantedLst) == 1)
                {
                    Console.WriteLine("une fois sortie du champ d'asteroids vous vous apercevez que votre cible c'est ecraser");
                }
                else
                {
                    Console.WriteLine("par chance votre strategie a fonctionnee l'enemie n'a pas eu le temps de bouger le petit doit");
                }

                Console.WriteLine("Felicitation vous etes venue a bout de votre adversaire ! il est temps de rentrer encaisser votre prime");
            }
            else
            {
                Console.WriteLine("en face de vous ce trouve un avant-post pirate");
                Console.WriteLine("pour affronter une flotte il faut etre methodique. par ou voulez vous commencer ?");
                if (base.Selector(destinationoutpostLst) == 1)
                {
                    Console.WriteLine("super, vous etes arriver a saboter la station ainsi que condamner les hangars " +
                        "pour qu'aucun vaissaux ne sortent");
                    Console.WriteLine("la base et inactive mais pas pour longtemps just assez pour pouvoir causer d'assez lourd degas ");
                }
                else
                {
                    Console.WriteLine("");
                }
                Console.WriteLine("felicitation l'avant post et HS rentrez pour toucher votre prime");
            }
        }
    }
}
