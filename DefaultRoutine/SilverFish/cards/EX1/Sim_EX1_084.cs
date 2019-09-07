using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_EX1_084 : SimTemplate //* Warsong Commander
    {
		//Your Charge minions have +1 Attack.

        public override void onAuraStarts(Playfield p, Minion own)
		{
            if (own.own)
            {
                foreach (Minion m in p.ownMinions)
                {
                    if (m.charge > 0) p.minionGetBuffed(m, 1, 0);
                }
            }
            else
            {
                foreach (Minion m in p.enemyMinions)
                {
                    if (m.charge > 0) p.minionGetBuffed(m, 1, 0);
                }
            }
            
		}

        public override void onAuraEnds(Playfield p, Minion own)
        {
            if (own.own)
            {
                foreach (Minion m in p.ownMinions)
                {
                    if (m.charge > 0) p.minionGetBuffed(m, -1, 0);
                }
            }
            else
            {
                foreach (Minion m in p.enemyMinions)
                {
                    if (m.charge > 0) p.minionGetBuffed(m, -1, 0);
                }
            }
        }
	}
}