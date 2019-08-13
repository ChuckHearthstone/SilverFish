using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_KAR_094 : SimTemplate //Deadly Fork
    {
        // Deathrattle: Add a 3/2 weapon to your hand.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(CardDB.cardIDEnum.KAR_094a, m.own, true);
        }
    }
}