using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_047t2 : SimTemplate //* Fatespinner on board 2x
    {
        // Deathrattle: Give all minions +2/+2, then deal 3 damage to them.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.allMinionOfASideGetBuffed(true, 2, 2);
            p.allMinionOfASideGetBuffed(false, 2, 2);
            p.allMinionsGetDamage(3);
        }
    }
}