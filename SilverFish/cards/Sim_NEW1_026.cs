using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_NEW1_026 : SimTemplate //* Violet Teacher
    {
        //Whenever you cast a spell, summon a 1/1 Violet Apprentice.

        public CardDB.Card card = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.NEW1_026t);

        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (wasOwnCard == triggerEffectMinion.own && hc.card.type == CardDB.cardtype.SPELL)
            {
                p.callKid(card, triggerEffectMinion.zonepos, wasOwnCard);
            }
        }
    }
}
