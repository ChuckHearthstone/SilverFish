using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_LOE_053 : SimTemplate //* Djinni of Zephyrs
	{
		//Whenever you cast a spell on another friendly minion, cast a copy of it on this one.

        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (hc.card.type == CardDB.cardtype.SPELL && hc.target != null && hc.target.own == wasOwnCard)
            {
                if (hc.target.own == triggerEffectMinion.own && hc.target.entitiyID != triggerEffectMinion.entitiyID)
                {
                    hc.card.sim_card.onCardPlay(p, wasOwnCard, triggerEffectMinion, hc.extraParam2);
                }
            }
        }
    }
}