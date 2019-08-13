using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_026 : SimTemplate //Feign Death
    {

        //   Trigger all Deathrattles on your minions.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.doDeathrattles(ownplay ? new List<Minion>(p.ownMinions) : new List<Minion>(p.enemyMinions));
        }
    }

}