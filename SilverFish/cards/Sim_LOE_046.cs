using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_LOE_046 : SimTemplate //huge toad
    {

        //  Deathrattle: Deal 1 damage to a random enemy.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.doDmgToRandomEnemyCLIENT2(1, true, m.own);
        }
    }
}