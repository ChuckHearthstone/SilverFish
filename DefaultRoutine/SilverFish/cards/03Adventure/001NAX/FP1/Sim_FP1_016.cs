using System.Collections.Generic;
using HREngine.Bots;

namespace SilverFish.cards._03Adventure._001NAX.FP1
{
    class Sim_FP1_016 : SimTemplate //* Wailing Soul
	{
        // Battlecry: Silence your other minions.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
                if (m.entitiyID != own.entitiyID) p.minionGetSilenced(m);
            }
		}
	}
}