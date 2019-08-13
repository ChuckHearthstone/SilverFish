using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_NAX7_05 : SimTemplate //* Mind Control Crystal
	{
		// Activate the Crystal to control the Understudies!

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            foreach (Minion m in ownplay ? p.enemyMinions : p.ownMinions)
            {
				if (m.name == CardDB.cardName.understudy) p.minionGetControlled(m, ownplay, true);
			}
		}
	}
}