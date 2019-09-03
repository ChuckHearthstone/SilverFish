using System.Collections.Generic;
using HREngine.Bots;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_855: SimTemplate //* Hyldnir Frostrider
    {
        // Battlecry: Freeze your other minions.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
                p.minionGetFrozen(m);
            }
        }
    }
}