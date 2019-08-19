using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_467: SimTemplate //* Deathspeaker
    {
        // Battlecry: Give a friendly minion Immune this turn.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null) target.immune = true;
        }
    }
}