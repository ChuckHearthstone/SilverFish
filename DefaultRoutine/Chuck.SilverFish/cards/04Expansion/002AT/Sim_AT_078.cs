using System.Collections.Generic;
using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_078 : SimTemplate //* Enter the Coliseum
	{
		//Destroy all minions except each player's highest Attack minion.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            List<Minion> temp = new List<Minion>(p.enemyMinions);
			if (temp.Count >= 2)
			{
				temp.Sort((a, b) => b.Attack.CompareTo(a.Attack));
				bool first = true;
				foreach (Minion m in temp)
				{
					if (first) { first = false; continue; }
					p.minionGetDestroyed(m);
				}
			}
			
			temp = new List<Minion>(p.ownMinions);
			if (temp.Count >= 2)
			{
				temp.Sort((a, b) => b.Attack.CompareTo(a.Attack));
				bool first = true;
				foreach (Minion m in temp)
				{
					if (first) { first = false; continue; }
					p.minionGetDestroyed(m);
				}
			}
		}
	}
}