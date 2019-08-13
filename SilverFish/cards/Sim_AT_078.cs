using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_078 : SimTemplate //Enter the Coliseum
    {

        //   Destroy all minions except each player's highest Attack minion.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int maxid = 0;
            int maxat = -1;
            foreach (Minion m in p.ownMinions)
            {
                if (m.Angr > maxat)
                {
                    maxat = m.Angr;
                    maxid = m.entityID;
                }
            }

            foreach (Minion m in p.ownMinions)
            {
                if (m.entityID!=maxid)
                {
                    p.minionGetDestroyed(m);
                }
            }

            maxid = 0;
            maxat = -1;
            foreach (Minion m in p.enemyMinions)
            {
                if (m.Angr > maxat)
                {
                    maxat = m.Angr;
                    maxid = m.entityID;
                }
            }

            foreach (Minion m in p.enemyMinions)
            {
                if (m.entityID != maxid)
                {
                    p.minionGetDestroyed(m);
                }
            }
        }
    }
}