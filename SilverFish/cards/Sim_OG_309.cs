using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_OG_309 : SimTemplate //* Princess Huhuran
    {
        //Battlecry: Trigger a friendly minion's Deathrattle effect immediately.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null) p.doDeathrattles(new List<Minion>() { target });
        }
    }
}