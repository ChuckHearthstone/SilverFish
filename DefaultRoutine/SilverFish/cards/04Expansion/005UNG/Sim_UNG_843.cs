using System.Collections.Generic;
using HREngine.Bots;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_843 : SimTemplate //* The Voraxx
	{
		//After you cast a spell on this minion, summon a 1/1 Plant and cast another copy on it.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.UNG_999t2t1); //Plant
        
        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (hc.card.type == CardDB.CardType.SPELL && hc.target != null && hc.target.entitiyID == triggerEffectMinion.entitiyID)
            {
                List<Minion> tmp = triggerEffectMinion.own ? p.ownMinions : p.enemyMinions;

                if (tmp.Count < 7)
                {
                    p.CallKid(kid, triggerEffectMinion.zonepos, triggerEffectMinion.own);
                    hc.card.CardSimulation.onCardPlay(p, wasOwnCard, tmp[triggerEffectMinion.zonepos], hc.extraParam2);
                }
            }
        }
    }
}