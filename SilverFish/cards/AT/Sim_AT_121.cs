using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_AT_121 : SimTemplate //* Crowd Favorite
	{
		//Whenever you play a card with Battlecry, gain +1/+1.

        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (triggerEffectMinion.own == wasOwnCard && hc.card.battlecry)
            {
				p.minionGetBuffed(triggerEffectMinion, 1, 1);
            }
        }
	}
}