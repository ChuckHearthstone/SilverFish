using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_CS2_026 : SimTemplate //* Frost Nova
    {
        // Freeze all enemy minions.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            List<Minion> temp = (ownplay) ? p.enemyMinions : p.ownMinions;
            foreach (Minion t in temp)
            {
                p.minionGetFrozen(t);
            }
        }
    }
}