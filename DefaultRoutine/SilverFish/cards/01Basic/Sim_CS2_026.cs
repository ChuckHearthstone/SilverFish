using System.Collections.Generic;
using HREngine.Bots;

namespace SilverFish.cards._01Basic
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