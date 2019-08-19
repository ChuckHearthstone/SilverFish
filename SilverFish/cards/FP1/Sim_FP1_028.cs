using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_FP1_028 : SimTemplate //undertaker
	{

//    Whenever you summon a minion with Deathrattle, gain +1 Attack.

        public override void onMinionIsSummoned(Playfield p, Minion triggerEffectMinion, Minion summonedMinion)
        {
            if (triggerEffectMinion.own == summonedMinion.own)
            {
                if (summonedMinion.handcard.card.deathrattle) p.minionGetBuffed(triggerEffectMinion,1,0);
            }
        }

	}
}