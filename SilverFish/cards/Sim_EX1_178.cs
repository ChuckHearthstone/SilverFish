using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_EX1_178 : SimTemplate //ancientofwar
    {
        //Choose One - +5 Attack; or +5 Health and Taunt.
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (choice == 1 || (p.anzOwnFandralStaghelm > 0 && own.own))
            {
                p.minionGetBuffed(own, 5, 0);
            }
            if (choice == 2 || (p.anzOwnFandralStaghelm > 0 && own.own))
            {
                p.minionGetBuffed(own, 0, 5);
                own.taunt = true;
            }
        }
    }
}