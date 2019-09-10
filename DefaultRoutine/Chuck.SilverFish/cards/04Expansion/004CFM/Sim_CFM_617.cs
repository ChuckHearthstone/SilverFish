using System.Collections.Generic;
using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_617 : SimTemplate //* Celestial Dreamer
	{
		// Battlecry: If a friendly minion has 5 or more attack, gain +2/+2.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            List<Minion> temp = (m.own) ? p.ownMinions : p.enemyMinions;
            foreach (Minion mnn in temp)
            {
                if (mnn.Attack > 4)
                {
                    p.minionGetBuffed(m, 2, 2);
                    break;
                }
            }
        }
    }
}