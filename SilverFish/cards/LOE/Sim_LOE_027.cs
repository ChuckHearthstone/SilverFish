using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_LOE_027 : SimTemplate //* Sacred Trial
	{
		//Secret: When your opponent has at least 3 minions and plays another, destroy it.

		public override void onSecretPlay(Playfield p, bool ownplay, Minion target, int number)
        {
            List<Minion> temp = (ownplay) ? p.enemyMinions : p.ownMinions;
            if (temp.Count > 3) p.minionGetDestroyed(target);
        }
    }
}