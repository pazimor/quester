using System;
using System.Collections.Generic;
using System.Text;

namespace quester
{
    class exploration : mission
    {
        List<string> ambushLueurLst = new List<string>();

        List<string> destinationPirateLst = new List<string>();
        List<string> destinationUnknownLst = new List<string>();

        public exploration()
        {
            //creation des lists
            ambushLueurLst.Add("vous allez jeter un oeil (peut-etre une grande decouverte ?).");
            ambushLueurLst.Add("vous continuer votre chemain (peut etre encore un coup des pirates).");

            destinationPirateLst.Add("vous infiltrez la base pour recuperer des donnees sensibles.");
            destinationPirateLst.Add("vous tentez de reperer les lieu pour une future attack et venir preparer.");

            destinationUnknownLst.Add("vous cherchez des organismes vivants ainsi que tout autres element pouvant etre nouveaux.");
            destinationUnknownLst.Add("vous scanner les plannetes du secteur en surface pour cartographier ce secteur.");
        }

        public override string type()
        {
            //titre de mission
            return "mission d'exploration";
        }

        public override void nextStep()
        {

        }

        public override void ambush()
        {
            //embuscade story
            Console.WriteLine("lors de votre voyage vous appercevez une lueur puissante sur une planete.");
            Console.WriteLine("que faite vous ??");
            if (base.Selector(ambushLueurLst) == 1)
            {
                Console.WriteLine("vous vous dirrigez vers la planete");
                if (base.rand.Next(0, 2) == 0)
                {
                    Console.WriteLine("vous trouvez un objet de source inconue inoffensif\n" +
                        "vous decider de le prendre avec vous pour l'examiner dans la station la plus proche");
                }
                else
                {
                    Console.WriteLine("en vous raprochant de la planete vous arrivez a distinguer\n" +
                        "les couleurs d'une faction pirate redoutable il vaudrais mieux pour vous de vous eloigner d'ici");
                }
            }
            else
            {
                Console.WriteLine("vous continuer votre chemain comme si de rien etait");
            }
        }

        public override void destination()
        {

            Console.WriteLine("vous penetrez dans un sercteur non repertorier");
            if (base.rand.Next(0, 2) == 1)
            {
                //outposte story
                Console.WriteLine("ce secteur semble etre sous influence pirate.");
                Console.WriteLine("que voulez vous faire ?");
                if(base.Selector(destinationPirateLst) == 1)
                {
                    Console.WriteLine("vous fouiller les fichiers de la base tout en retant le plus discret possible." +
                        " apres une analyse des serveurs enemies vous trouver des donnees encryptees qui pourrons etre" +
                        " analysee et decryptees dans une station\n" +
                        "vous vous dirriger vers votre point de depart pour faire un rapport sur la situation");
                }
                else
                {
                    Console.WriteLine("vous recherchez un maximum d'informations : tourelles defensives," +
                        " nombre de veseau maximum pouvant etre ravitailler, etc ...\n" +
                        "vous reviendrez plus tard avec du renfort\n" +
                        "pour l'instant vous vous dirriger vers votre point de depart pour faire un rapport sur la situation");
                }
            }
            else
            {
                //discovery story
                Console.WriteLine("ce secteur semble etre inconue par la galaxie.");
                Console.WriteLine("que voulez vous faire ?");
                if (base.Selector(destinationUnknownLst) == 1)
                {
                    Console.WriteLine("vous avez scanner toutes les plannete, asteroids, et autre elements du systeme" +
                        " mais rien d'inconue ou d'anormale n'a etait decouvert dans ce dernier.");
                }
                else
                {
                    Console.WriteLine("vous cartographiez le secteur.");
                }
                Console.WriteLine("il est temps de retourner sur vos pas pour vos merger donnees avec la base de donnees galactic");
            }
        }
    }
}
