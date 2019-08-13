using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_OG_271 : SimTemplate //* Scaled Nightmare
	{
		//At the start of your turn, double this minion's Attack.
		
		public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (triggerEffectMinion.own == turnStartOfOwner)
            {
                p.minionGetBuffed(triggerEffectMinion, 2 * triggerEffectMinion.Angr, 0);
            }
        }
	}
}