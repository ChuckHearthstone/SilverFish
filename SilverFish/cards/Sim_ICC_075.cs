using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_075: SimTemplate //* Despicable Dreadlord
    {
        // At the end of your turn, deal 1 damage to all enemy minions.

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                p.allMinionOfASideGetDamage(!triggerEffectMinion.own, 1);
            }
        }
    }
}