using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_NAX4_05 : SimTemplate //* Plague
	{
		// Destroy all non-Skeleton minions.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
			foreach (Minion m in p.ownMinions)
            {
                if (m.name != CardDB.cardName.skeleton) p.minionGetDestroyed(m);
            }
            foreach (Minion m in p.enemyMinions)
            {
                if (m.name != CardDB.cardName.skeleton) p.minionGetDestroyed(m);
            }
		}
	}
}