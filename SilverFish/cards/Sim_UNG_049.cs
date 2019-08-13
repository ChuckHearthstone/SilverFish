using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_049 : SimTemplate //* Tar Lurker
	{
		//Taunt. Has +3 Attack during your opponent's turn.

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                p.minionGetBuffed(triggerEffectMinion, 3, 0);
            }
        }

        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (triggerEffectMinion.own == turnStartOfOwner)
            {
                p.minionGetBuffed(triggerEffectMinion, -3, 0);
            }
        }
    }
}