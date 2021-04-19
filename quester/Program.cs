using System;
using System.Collections.Generic;

namespace quester
{
    class Program
    {
        //list de quests
        private List<mission> owned = new List<mission>();
        private List<mission> divercity = new List<mission>();

        public Program()
        {
            //rempliseage de divercity
            divercity.Add(new mining());
            divercity.Add(new exploration());
            divercity.Add(new bountyHunter());
        }

        public void addQuestToInventory(int number)
        {
            //ajoute des quests dans l'inventaire (number et determiner par la fonction selector)
            if (number == 1)
            {
                this.owned.Add(new mining());
                //quest minage
                Console.WriteLine("une quete de minage a etait ajouter a votre journal de bord");
            }
            else if (number == 2)
            {
                this.owned.Add(new exploration());
                //quest explo
                Console.WriteLine("une quete d'exploration a etait ajouter a votre journal de bord");
            }
            else if (number == 3)
            {
                this.owned.Add(new bountyHunter());
                //quest chasseur de primes
                Console.WriteLine("une quete de chasseur de prime a etait ajouter a votre journal de bord");

            }
        }

        void deleteFinishedQuest()
        {
            //a chaque debut de boucle de jeu detruit/rend la quete fini si il y en a une
            for (int i = 0; i < owned.Count; i++)
            {
                if (owned[i].isFinish == true)
                {
                    owned.RemoveAt(i);
                    break;
                }
            }
        }

        void questProgress()
        {
            // la boucle principale (comparer a une station)
            deleteFinishedQuest();
            Console.WriteLine("\n\nque voulez vous faire ?");
            Console.WriteLine("\tsuivre une quete disponible dans votre journale de bord ?");
            int i = 0;
            //prompt toutes les options de quetes
            foreach (mission a in this.owned)
            {
                i += 1;
                Console.WriteLine("\t\t" + i + ") " + a.type());
            }
            i += 1;
            Console.WriteLine("\t"+ i + ") recuperer une autre quete ?");
            i += 1;
            Console.WriteLine("\t" + i + ") quitter");
            // execute une action en fonction du choix de l'utilisateur
            int choice = Selector(this.owned.Count + 2);
            if (choice <= this.owned.Count)
            {
                this.owned[choice - 1].travelling();
                //progress dans une quete
            }
            else if (choice == this.owned.Count + 1)
            {
                //recuperer une quete
                getQuest();
            }
            else
            {
                //exit
                System.Environment.Exit(1);
            }
        }

        int Selector(int number)
        {
            //note number should be between 0 and 9

            //recuper le choix de l'utilisateur
            char ret = Console.ReadLine()[0];
            return (ret > '0' && ret <= '0'+ number) ? ret - '0' : Selector(number);
        }

        void getQuest()
        {
            //recuperer une quete
            Console.WriteLine("veuiller selectionner un type de mission");
            int i = 0;
            foreach (mission a in this.divercity)
            {
                i += 1;
                Console.WriteLine(i + ") " + a.type());
            }
            addQuestToInventory(Selector(3));
        }

        static void Main(string[] args)
        {
            //main demarre le programe et boucle pour avoir toujours une nouvelle quete recuperable
            Program quester = new Program();
            Console.WriteLine("=== bienvenue dans quester ===");
            quester.getQuest();
            while (true)
            {
                quester.questProgress();
            }
        }

        
    }
}
