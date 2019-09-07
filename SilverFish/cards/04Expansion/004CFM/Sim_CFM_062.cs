using System.Collections.Generic;
using HREngine.Bots;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_062 : SimTemplate //* Grimestreet Protector
	{
		// Battlecry: Give adjacent minions Divine Shield.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            List<Minion> temp = (m.own) ? p.ownMinions : p.enemyMinions;
            foreach (Minion mnn in temp)
            {
                if (mnn.zonepos == m.zonepos - 1 || mnn.zonepos == m.zonepos + 1)
                {
                    mnn.divineshild = true;
                }
            }
        }
    }
}