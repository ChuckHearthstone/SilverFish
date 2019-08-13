using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_BRM_029 : SimTemplate //* Rend Blackhand
    {
        // Battlecry: If you're holding a Dragon, destroy a Legendary minion.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (target != null) p.minionGetDestroyed(target);
        }
    }
}