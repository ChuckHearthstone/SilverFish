using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_KAR_089 : SimTemplate //Malchezaar's Imp
    {
        // Whenever you discard a card, draw a card.

        public override void onCardWasDiscarded(Playfield p, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (triggerEffectMinion.own == wasOwnCard)
            {
                p.drawACard(CardDB.cardName.unknown, wasOwnCard);
            }
        }
    }
}