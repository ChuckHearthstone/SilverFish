using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_ICC_314t3 : SimTemplate //* Doom Pact
    {
        // Destroy all minions. Remove the top card from your deck for each minion destroyed.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int anz = p.ownMinions.Count + p.enemyMinions.Count;
            p.allMinionsGetDestroyed();
            if (ownplay) p.ownDeckSize = Math.Max(0, p.ownDeckSize - anz);
            else p.enemyDeckSize = Math.Max(0, p.enemyDeckSize - anz);
        }
    }
}