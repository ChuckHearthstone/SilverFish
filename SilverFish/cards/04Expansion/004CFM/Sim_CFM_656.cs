using System.Collections.Generic;
using HREngine.Bots;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_656 : SimTemplate //* Streetwise Investigator
	{
		// Battlecry: Enemy minions lose Stealth.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            List<Minion> temp = (m.own) ? p.enemyMinions : p.ownMinions;
            foreach (Minion mnn in temp)
            {
                mnn.stealth = false;
            }
        }
    }
}