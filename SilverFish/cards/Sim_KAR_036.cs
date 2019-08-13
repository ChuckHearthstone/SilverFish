using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_KAR_036 : SimTemplate //* Arcane Anomaly
	{
		//Whenever you cast a spell, give this minion +1 Health.
		
        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (triggerEffectMinion.own == wasOwnCard && hc.card.type == CardDB.cardtype.SPELL)
            {
				p.minionGetBuffed(triggerEffectMinion, 0, 1);
            }
        }
	}
}