using System.Collections.Generic;
using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_671 : SimTemplate //* Cryomancer
	{
		// Battlecry: Gain +2/+2 if an enemy is Frozen.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            List<Minion> temp = (m.own) ? p.enemyMinions : p.ownMinions;
            foreach (Minion mnn in temp)
            {
                if (mnn.frozen)
                {
                    p.minionGetBuffed(m, 2, 2);
                    break;
                }
            }
        }
    }
}