using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CFM_609 : SimTemplate //* Fel Orc Soulfiend
	{
		// At the start of your turn, deal 2 damage to this minion.

        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (triggerEffectMinion.own == turnStartOfOwner)
            {
                p.minionGetDamageOrHeal(triggerEffectMinion, 2);
            }
        }
    }
}