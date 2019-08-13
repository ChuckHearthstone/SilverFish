using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_073 : SimTemplate // Competitive Spirit
    {

        //    When your turn starts, give your minions +1/+1.


        public override void onSecretPlay(Playfield p, bool ownplay, int number)
        {
            foreach (Minion m in (ownplay) ? p.ownMinions : p.enemyMinions)
            {
                p.minionGetBuffed(m, 1, 1);
            }
        }
    }
}