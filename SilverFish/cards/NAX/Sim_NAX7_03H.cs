using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_NAX7_03H : SimTemplate //* Unbalancing Strike
	{
		// Hero Power: Deal 4 damage.
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
			int dmg = (ownplay) ? p.getHeroPowerDamage(4) : p.getEnemyHeroPowerDamage(4);
            p.minionGetDamageOrHeal(target, dmg);
        }
	}
}