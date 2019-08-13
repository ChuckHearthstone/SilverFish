using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_NEW1_012 : SimTemplate //* Mana Wyrm
	{
		//Whenever you cast a spell, gain +1 Attack.

        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (triggerEffectMinion.own == wasOwnCard && hc.card.type == CardDB.cardtype.SPELL)
            {
				p.minionGetBuffed(triggerEffectMinion, 1, 0);
            }
        }
	}
}