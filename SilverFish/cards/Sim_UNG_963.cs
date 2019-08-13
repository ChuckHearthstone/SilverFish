using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_963 : SimTemplate //* Lyra the Sunshard
	{
		//Whenever you cast a spell, add a random Priest spell to your hand.

        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (hc.card.type == CardDB.cardtype.SPELL && wasOwnCard == triggerEffectMinion.own)
            {
                p.drawACard(CardDB.cardName.unknown, wasOwnCard);
            }
        }
	}
}