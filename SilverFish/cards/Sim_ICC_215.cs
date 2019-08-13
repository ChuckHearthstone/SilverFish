using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_215: SimTemplate //* Archbishop Benedictus
    {
        // Battlecry: Shuffle a copy of your opponent's deck into your deck.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                p.ownDeckSize += p.enemyDeckSize;
                p.evaluatePenality -= 6;
            }
            else p.enemyDeckSize += p.ownDeckSize;
        }
    }
}