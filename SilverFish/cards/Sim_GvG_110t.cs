using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_110t : SimTemplate //Boom Bot
    {

        //  Deathrattle: Deal 1-4 damage to a random enemy.

        

        public override void onDeathrattle(Playfield p, Minion m)
        {
            int dmg = (m.own ? 2 : 3);
            p.doDmgToRandomEnemyCLIENT2(dmg, true, m.own);
        }
    }
}