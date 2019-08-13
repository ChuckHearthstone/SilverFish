using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CFM_614 : SimTemplate //* Mark of the Lotus
	{
		// Give your minions +1/+1.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            List<Minion> temp = (ownplay) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
                p.minionGetBuffed(m, 1, 1);
            }
        }
    }
}