using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_092: SimTemplate //* Acherus Veteran
    {
        // Battlecry: Give a friendly minion +1 Attack.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null) p.minionGetBuffed(target, 1, 0);
        }
    }
}