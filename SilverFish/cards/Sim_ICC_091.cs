using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_091: SimTemplate //* Dead Man's Hand
    {
        // Shuffle a copy of your hand into your deck.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay) p.ownDeckSize += p.owncards.Count;
            else p.enemyDeckSize += p.enemyAnzCards;
        }
    }
}