using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_LOE_018 : SimTemplate //* Tunnel Trogg
	{
		//Whenether you Overloaded, gain +1 Attack per locked Mana Crystal.

        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (wasOwnCard == triggerEffectMinion.own && hc.card.overload > 0)
            {
                p.minionGetBuffed(triggerEffectMinion, hc.card.overload, 0);
            }
        }

    }
}