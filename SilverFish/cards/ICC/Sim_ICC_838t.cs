using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_838t : SimTemplate //* Frozen Champion
    {
        // Deathrattle: Add a random Legendary minion to your hand.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(CardDB.cardName.unknown, m.own, true);
            p.drawACard(CardDB.cardName.unknown, m.own, true);//bonus
        }
    }
}