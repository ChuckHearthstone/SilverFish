using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_BRMA12_3 : SimTemplate //* Brood Affliction: Red
	{
		//While this is in your hand, take 1 damage at the start of your turn.

        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (triggerEffectMinion.own == turnStartOfOwner)
            {
                p.minionGetDamageOrHeal(turnStartOfOwner ? p.ownHero : p.enemyHero, 1, true);
            }
        }
    }
}