using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CFM_621t24 : SimTemplate //* Goldthorn
	{
		// Give your minions +4 Health.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
			p.allMinionOfASideGetBuffed(ownplay, 0, 4);
		}
	}
}