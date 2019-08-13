using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_AT_025 : SimTemplate //* Dark Bargain
	{
		//Destroy 2 random enemy minion. Discard 2 random cards.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            List<Minion> temp = (ownplay) ? new List<Minion>(p.enemyMinions) : new List<Minion>(p.ownMinions);
			if (temp.Count >= 2)
			{
				temp.Sort((a, b) => a.Angr.CompareTo(b.Angr));
				bool enough = false;
				foreach (Minion enemy in temp)
				{
					p.minionGetDestroyed(enemy);
					if (enough) break;
					enough = true;
				}
                p.discardCards(2, ownplay);
			}
		}
	}
}