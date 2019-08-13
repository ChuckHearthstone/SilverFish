using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_OG_195b : SimTemplate //* Big Wisps
    {
        // Give your minions +2/+2.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.allMinionOfASideGetBuffed(ownplay, 2, 2);
        }
    }
}