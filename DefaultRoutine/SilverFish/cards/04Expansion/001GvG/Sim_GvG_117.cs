using HREngine.Bots;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_GVG_117 : SimTemplate //* Gazlowe
    {

        //   Whenever you cast a 1-mana spell, add a random Mech to your hand.
        //(we have to use current cost)

        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (triggerEffectMinion.own == wasOwnCard)
            {
                if (hc.card.type == CardDB.CardType.SPELL && hc.manacost == 1)
                {
                    p.drawACard(CardDB.CardName.shieldedminibot, wasOwnCard, true);
                }
            }
        }
    }
}