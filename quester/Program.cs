using System;
using System.Collections.Generic;

namespace quester
{
    class Program
    {
        private List<mission> owned = new List<mission>();
        private List<mission> divercity = new List<mission>();

        public Program()
        {
            divercity.Add(new mining());
            divercity.Add(new exploration());
            divercity.Add(new bountyHunter());
        }

        public void addQuestToInventory(int number)
        {
            if (number == 1)
            {
                this.owned.Add(new mining());
                Console.WriteLine("une quete de minage a etait ajouter a votre journal de bord");
            }
            else if (number == 2)
            {
                this.owned.Add(new exploration());
                Console.WriteLine("une quete d'exploration a etait ajouter a votre journal de bord");
            }
            else if (number == 3)
            {
                this.owned.Add(new bountyHunter());
                Console.WriteLine("une quete de chasseur de prime a etait ajouter a votre journal de bord");

            }
        }

        void questProgress()
        {
            Console.WriteLine("\n\nque voulez vous faire ?");
            Console.WriteLine("\tsuivre une quete disponible dans votre journale de bord ?");
            int i = 0;
            foreach (mission a in this.owned)
            {
                i += 1;
                Console.WriteLine("\t\t" + i + ") " + a.type());
            }
            i += 1;
            Console.WriteLine("\t"+ i + ") requperer une autre quete ?");
            int choice = Selector(this.owned.Count + 1);
            if (choice <= this.owned.Count)
            {
                //grab quest and progress
            }
            else
            {
                getQuest();
            }
        }

        int Selector(int number)
        {
            //note number should be between 0 and 9

            char ret = Console.ReadLine()[0];
            return (ret > '0' && ret <= '0'+ number) ? ret - '0' : Selector(number);
        }

        void getQuest()
        {
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
