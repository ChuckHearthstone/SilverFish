using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._01Basic._00Neutral
{
    class Sim_NEW1_026 : SimTemplate //* Violet Teacher
    {
        //Whenever you cast a spell, summon a 1/1 Violet Apprentice.

        public CardDB.Card card = CardDB.Instance.getCardDataFromID(CardIdEnum.NEW1_026t);

        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (wasOwnCard == triggerEffectMinion.own && hc.card.type == CardType.SPELL)
            {
                p.CallKid(card, triggerEffectMinion.zonepos, wasOwnCard);
            }
        }
    }
}
