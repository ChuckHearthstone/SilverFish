using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_BRMA04_2 : SimTemplate //* Magma Pulse
	{
		// Hero Power: Deal 1 damage to all minions.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getHeroPowerDamage(1) : p.getEnemyHeroPowerDamage(1);
			p.allMinionsGetDamage(dmg);
		}
	}
}