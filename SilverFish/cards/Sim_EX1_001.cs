using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_001 : SimTemplate //lightwarden
	{

        //   Whenever a character is healed, gain +2 Attack.
        public override void onAHeroGotHealedTrigger(Playfield p, Minion triggerEffectMinion)
        {
            p.minionGetBuffed(triggerEffectMinion, 2, 0);
        }

        public override void onAMinionGotHealedTrigger(Playfield p, Minion triggerEffectMinion)
        {
            p.minionGetBuffed(triggerEffectMinion, 2, 0);
        }

	}
}