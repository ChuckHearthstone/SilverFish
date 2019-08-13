using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_BRMA14_5H : SimTemplate //* 4/4 toxitron
	{
		// At the start of your turn, deal 1 damage to all other minions.

		public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
		{
            if (triggerEffectMinion.own == turnStartOfOwner)
            {
                p.allMinionsGetDamage(1, triggerEffectMinion.entitiyID);
            }
		}
	}
}