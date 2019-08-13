using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_099: SimTemplate //* Ticking Abomination
    {
        // Deathrattle: Deal 5 damage to your minions.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.allMinionOfASideGetDamage(m.own, 5);
        }
    }
}