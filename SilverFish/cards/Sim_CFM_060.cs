using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CFM_060 : SimTemplate //* Red Mana Wyrm
	{
		// Whenever you cast a spell, gain +2 Attack.

        public override void onCardIsGoingToBePlayed(Playfield p, CardDB.Card c, bool wasOwnCard, Minion triggerEffectMinion, Minion target, int choice)
        {
            if (triggerEffectMinion.own == wasOwnCard && c.type == CardDB.cardtype.SPELL)
            {
                p.minionGetBuffed(triggerEffectMinion, 2, 0);
            }
        }
    }
}