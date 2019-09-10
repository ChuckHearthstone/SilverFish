using System.Collections.Generic;
using Chuck.SilverFish;

namespace SilverFish.cards._02Classic
{
    class Sim_EX1_573a : SimTemplate //* Demigod's Favor
	{
        //Give your other minions +2/+2.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            List<Minion> temp = (ownplay) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
                if (target.entitiyID != m.entitiyID) p.minionGetBuffed(m, 2, 2);
            }
		}

	}
}