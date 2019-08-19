using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_AT_063t : SimTemplate //* Dreadscale
	{
		//At the end of your turn, deal 1 damage to all other minions.

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                p.allMinionsGetDamage(1, triggerEffectMinion.entitiyID);
            }
        }
	}
}