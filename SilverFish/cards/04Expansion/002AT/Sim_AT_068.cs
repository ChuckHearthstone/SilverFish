using System.Collections.Generic;
using HREngine.Bots;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_068 : SimTemplate //* Bolster
	{
		//Give your Taunt minions +2/+2.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            List<Minion> temp = (ownplay) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
				if (m.taunt) p.minionGetBuffed(m, 2, 2);
            }
        }
    }
}
