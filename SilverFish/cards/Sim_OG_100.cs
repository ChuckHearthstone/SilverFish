using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_OG_100 : SimTemplate //* Shadow Word: Horror
    {
        //Destroy all minions with 2 or less Attack.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            foreach (Minion m in p.enemyMinions)
            {
                if (m.Angr < 3) p.minionGetDestroyed(m);
            }
            foreach (Minion m in p.ownMinions)
            {
                if (m.Angr < 3) p.minionGetDestroyed(m);
            }
        }
    }
}