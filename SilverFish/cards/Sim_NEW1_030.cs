using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_NEW1_030 : SimTemplate //* Deathwing
	{
        //Battlecry: Destroy all other minions and discard your hand.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            foreach (Minion m in p.ownMinions)
            {
                if (m.entitiyID != own.entitiyID) p.minionGetDestroyed(m);
            }
            foreach (Minion m in p.enemyMinions)
            {
                if (m.entitiyID != own.entitiyID) p.minionGetDestroyed(m);
            }
            p.discardCards(10, own.own);
		}
	}
}