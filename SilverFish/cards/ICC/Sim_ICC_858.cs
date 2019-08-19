using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_858: SimTemplate //* Bolvar, Fireblood
    {
        // Divine Shield. After a friendly minion loses Divine Shield, gain +2 Attack.

        public override void onMinionLosesDivineShield(Playfield p, Minion m, int num)
        {
            p.minionGetBuffed(m, 2 * num, 0);
        }
    }
}