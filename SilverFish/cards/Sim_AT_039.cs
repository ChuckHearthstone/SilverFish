using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_AT_039 : SimTemplate //* Savage Combatant
	{
		//Inspire: Give your hero +2 Attack this turn.

		public override void onInspire(Playfield p, Minion m, bool own)
        {
			if (m.own == own)
			{
				p.minionGetTempBuff(own ? p.ownHero : p.enemyHero, 2, 0);
			}
        }
	}
}