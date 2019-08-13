using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_AT_110 : SimTemplate //* Coliseum Manager
	{
		//Inspire: Return this minion to your hand.

		public override void onInspire(Playfield p, Minion m, bool own)
        {
			if (m.own == own)
			{
				p.minionReturnToHand(m, own, 0);
			}
        }
	}
}