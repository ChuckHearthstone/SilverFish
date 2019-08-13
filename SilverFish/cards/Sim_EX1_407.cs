using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_407 : SimTemplate //* Brawl
	{
        // Destroy all minions except one. (chosen randomly)

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            bool hasWinner = false;
            foreach (Minion m in p.enemyMinions)
            {
                if ((m.name == CardDB.cardName.darkironbouncer || m.name == CardDB.cardName.corendirebrew) && !hasWinner)
                {
                    hasWinner = true;
                    continue;
                }
                p.minionGetDestroyed(m);
            }
            foreach (Minion m in p.ownMinions)
            {
                if ((m.name == CardDB.cardName.darkironbouncer || m.name == CardDB.cardName.corendirebrew) && !hasWinner)
                {
                    hasWinner = true;
                    continue;
                }
                p.minionGetDestroyed(m);
            }
		}
	}
}