using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_LOE_086 : SimTemplate //Summoning Stone
	{

        CardDB.Card kid0 = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_231);

        //    Whenever you cast a spell, summon a random minion of the same Cost.
        public override void onCardIsGoingToBePlayed(Playfield p, CardDB.Card c, bool wasOwnCard, Minion triggerEffectMinion, Minion target, int choice)
        {
            if (triggerEffectMinion.own == wasOwnCard && c.type == CardDB.cardtype.SPELL)
            {
                int pos = (wasOwnCard) ? p.ownMinions.Count : p.enemyMinions.Count;
                p.callKid(p.getRandomCardForManaMinion(c.cost), pos, wasOwnCard);
            }
        }

	}
}