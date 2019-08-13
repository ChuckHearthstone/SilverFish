using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_KAR_041 : SimTemplate //Moat Lurker
    {
        // Battlecry: Destroy a minion. Deathrattle: Resummon it.
        
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null) p.minionGetDestroyed(target);
        }
    }
}