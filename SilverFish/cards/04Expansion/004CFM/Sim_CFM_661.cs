using System.Collections.Generic;
using HREngine.Bots;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_661 : SimTemplate //* Pint-Size Potion
	{
		// Give all enemy minions -3 Attack this turn only.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            List<Minion> temp = (ownplay) ? p.enemyMinions : p.ownMinions;
            foreach (Minion m in temp)
            {
                p.minionGetTempBuff(m, -3, 0);
            }
        }
    }
}