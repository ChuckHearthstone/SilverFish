using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_AT_090 : SimTemplate //* Mukla's Champion
	{
		//Inspire: Give your other minions +1/+1.

		public override void onInspire(Playfield p, Minion m, bool own)
        {
			if (m.own == own)
			{
				List<Minion> temp = (own) ? p.ownMinions : p.enemyMinions;
				foreach (Minion mnn in temp)
				{
                    if (m.entitiyID == mnn.entitiyID) continue;
					p.minionGetBuffed(mnn, 1, 1);
				}
			}
        }
	}
}