using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CFM_656 : SimTemplate //* Streetwise Investigator
	{
		// Battlecry: Enemy minions lose Stealth.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            List<Minion> temp = (m.own) ? p.enemyMinions : p.ownMinions;
            foreach (Minion mnn in temp)
            {
                mnn.stealth = false;
            }
        }
    }
}