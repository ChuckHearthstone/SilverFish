using System;
using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_911: SimTemplate //* Keening Banshee
    {
        // Whenever you play a card, remove the top 3 cards of your deck.

        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (triggerEffectMinion.own == wasOwnCard)
            {
                if (triggerEffectMinion.own)
                {
                    p.ownDeckSize = Math.Max(0, p.ownDeckSize - 3);
                }
                else
                {
                    p.enemyDeckSize = Math.Max(0, p.enemyDeckSize - 3);
                }
            }
        }
    }
}