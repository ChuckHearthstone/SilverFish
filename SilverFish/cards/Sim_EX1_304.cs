using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_EX1_304 : SimTemplate //* Void Terror
	{
        //Battlecry: Destroy the minions on either side of this minion and gain their Attack and Health.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;

            int angr = 0;
            int hp = 0;
            foreach (Minion m in temp)
            {
                if (m.zonepos == own.zonepos - 1 || m.zonepos == own.zonepos + 1)
                {
                    angr += m.Angr;
                    hp += m.Hp;
                    p.minionGetDestroyed(m);
                }
            }
            p.minionGetBuffed(own, angr, hp);
		}
	}
}