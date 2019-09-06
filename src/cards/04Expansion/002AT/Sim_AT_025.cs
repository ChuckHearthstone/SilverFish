using System.Collections.Generic;
using HREngine.Bots;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_025 : SimTemplate //* Dark Bargain
	{
		//Destroy 2 random enemy minion. Discard 2 random cards.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            List<Minion> temp = (ownplay) ? new List<Minion>(p.enemyMinions) : new List<Minion>(p.ownMinions);
			if (temp.Count >= 2)
			{
				temp.Sort((a, b) => a.Attack.CompareTo(b.Attack));
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