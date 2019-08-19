using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_407: SimTemplate //* Gnomeferatu
    {
        // Battlecry: Remove the top card of your opponent's deck.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own) p.enemyDeckSize = Math.Max(0, p.enemyDeckSize - 1);
            else p.ownDeckSize = Math.Max(0, p.ownDeckSize - 1);
        }
    }
}