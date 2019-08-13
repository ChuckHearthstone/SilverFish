using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_AT_119 : SimTemplate //* Kvaldir Raider
	{
		//Inspire: Gain +2/+2.

		public override void onInspire(Playfield p, Minion m, bool own)
        {
			if (m.own == own)
			{
				p.minionGetBuffed(m, 2, 2);
			}
        }
	}
}