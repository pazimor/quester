using System;
using System.Collections.Generic;
using System.Text;

namespace quester
{
    class bountyHunter : mission
    {
        List<string> ambushPirateLst = new List<string>();

        public bountyHunter()
        {
            ambushPirateLst.Add("vous afrontez les pirates");
            ambushPirateLst.Add("vous faites un detour pour ne pas vous faire repérer");
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
            // pirate base invading
            // wanted pirate with his crew
        }
    }
}
