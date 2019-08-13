using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_027: SimTemplate //* Bone Drake
    {
        // Deathrattle: Add a random Dragon to your hand.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(CardDB.cardName.faeriedragon, m.own, true);
        }
    }
}