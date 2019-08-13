using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_NAX15_04 : SimTemplate //* Chains
	{
		// Hero Power: Take control of a random enemy minion until end of turn.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            List<Minion> temp = (ownplay) ? p.enemyMinions : p.ownMinions;
            if (temp.Count <= 0) return;
            Minion m = p.searchRandomMinion(temp, searchmode.searchLowestHP);
            if (m != null)
			{
				m.shadowmadnessed = true;
				p.shadowmadnessed++;
				p.minionGetControlled(m, ownplay, false);
			}
		}
	}
}