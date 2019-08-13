using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_KAR_036 : SimTemplate //Arcane Anomaly
    {
        //   Whenever you cast a spell, give this minion +1 Health.

        public override void onCardIsGoingToBePlayed(Playfield p, CardDB.Card c, bool wasOwnCard, Minion triggerEffectMinion, Minion target, int choice)
        {
            if (wasOwnCard == triggerEffectMinion.own && c.type == CardDB.cardtype.SPELL)
            {
                p.minionGetBuffed(triggerEffectMinion, 0, 1);
            }
        }
    }
}