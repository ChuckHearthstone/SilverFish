using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_531 : SimTemplate //* scavenginghyena
	{
//    Whenever a friendly Beast dies, gain +2/+1.

        public override void onMinionDiedTrigger(Playfield p, Minion m, Minion diedMinion)
        {
            int diedMinions = (m.own) ? p.tempTrigger.ownBeastDied : p.tempTrigger.enemyBeastDied;
            if (diedMinions == 0) return;
            int residual = (p.pID == m.pID) ? diedMinions - m.extraParam2 : diedMinions;
            m.pID = p.pID;
            m.extraParam2 = diedMinions;
            if (residual >= 1)
            {
                p.minionGetBuffed(m, 2 * residual, residual);
            }
        }

	}
}