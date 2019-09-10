using System.Collections.Generic;
using Chuck.SilverFish;

namespace SilverFish.cards._01Basic._03Mage
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