using HREngine.Bots;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_GVG_028 : SimTemplate //Trade Prince Gallywix
    {

        //    Whenever your opponent casts a spell, gain a copy of it and give them a Coin.

        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            CardDB.Card c = hc.card;
            if (c.type == CardDB.CardType.SPELL && c.name != CardDB.CardName.gallywixscoin && wasOwnCard != triggerEffectMinion.own)
            {
                p.drawACard(c.cardIDenum, triggerEffectMinion.own, true);
                p.drawACard(CardDB.CardName.gallywixscoin, wasOwnCard, true);
            }
        }


    }

}