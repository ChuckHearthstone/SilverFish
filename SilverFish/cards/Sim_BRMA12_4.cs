using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_BRMA12_4 : SimTemplate //* Brood Affliction: Green
	{
		//While this is in your hand, restore 2 health to your opponent at the start of your turn.

        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (triggerEffectMinion.own == turnStartOfOwner)
            {
                p.minionGetDamageOrHeal(turnStartOfOwner ? p.ownHero : p.enemyHero, -2, true);
            }
        }
    }
}