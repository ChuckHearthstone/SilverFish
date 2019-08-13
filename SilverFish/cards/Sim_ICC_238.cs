using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_238: SimTemplate //* Animated Berserker
    {
        // After you play a minion deal 1 damage to it.

        public override void onMinionWasSummoned(Playfield p, Minion m, Minion summonedMinion)
        {
            if (summonedMinion.playedFromHand && summonedMinion.own == m.own && summonedMinion.entitiyID != m.entitiyID)
            {
                p.minionGetDamageOrHeal(summonedMinion, 1);
            }
        }
    }
}