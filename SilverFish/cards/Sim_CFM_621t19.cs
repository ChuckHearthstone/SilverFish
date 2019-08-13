using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CFM_621t19 : SimTemplate //* Icecap
	{
		// Freeze: 2 random enemy minions.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
			List<Minion> temp = (ownplay) ? p.enemyMinions : p.ownMinions;
			if (temp.Count > 2)
			{
				int anz = 0;
				target = p.searchRandomMinion(temp, searchmode.searchLowestHP);
                if (target != null && !target.frozen)
				{
                    p.minionGetFrozen(target);
					anz++;
				}
				foreach (Minion m in temp)
				{
					if (!m.frozen)
                    {
                        p.minionGetFrozen(m);
						anz++;
						if (anz > 1) break;
					}
				}
			}
			else
			{
				foreach (Minion m in temp)
                {
                    p.minionGetFrozen(m);
				}
			}
        }
    }
}