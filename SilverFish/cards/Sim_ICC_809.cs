using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_809: SimTemplate //* Plague Scientist
    {
        // Combo: Give a friendly minion Poisonous.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (p.cardsPlayedThisTurn >= 1 && target != null && own.own)
            {
                target.poisonous = true;
            }
        }
    }
}