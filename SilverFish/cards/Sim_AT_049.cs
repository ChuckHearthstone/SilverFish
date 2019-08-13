using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_AT_049 : SimTemplate //* Thunder Bluff Valiant
	{
		//Inspire: Give your Totems +2 Attack.

		public override void onInspire(Playfield p, Minion m, bool own)
        {
			if (m.own == own)
			{
				List<Minion> temp = (own) ? p.ownMinions : p.enemyMinions;
				foreach (Minion mnn in temp)
				{
					if ((TAG_RACE)mnn.handcard.card.race == TAG_RACE.TOTEM)
					{
						p.minionGetBuffed(mnn, 2, 0);
					}
				}
			}
        }
	}
}