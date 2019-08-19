using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CS2_084 : SimTemplate //* huntersmark
	{
        //Change a minion's Health to 1.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionSetLifetoX(target, 1);
		}

	}
}