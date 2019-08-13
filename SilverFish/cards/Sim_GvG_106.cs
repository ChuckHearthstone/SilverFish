using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_106 : SimTemplate //* Junkbot
    {
//   Whenever a friendly Mech dies, gain +2/+2.

        public override void onMinionDiedTrigger(Playfield p, Minion m, Minion diedMinion)
        {
            int diedMinions = (m.own) ? p.tempTrigger.ownMechanicDied : p.tempTrigger.enemyMechanicDied;
            if (diedMinions == 0) return;
            int residual = (p.pID == m.pID) ? diedMinions - m.extraParam2 : diedMinions;
            m.pID = p.pID;
            m.extraParam2 = diedMinions;
            for (int i = 0; i < residual; i++)
			{
                p.minionGetBuffed(m, 2 * residual, 2 * residual);
			}
        }
    }
}