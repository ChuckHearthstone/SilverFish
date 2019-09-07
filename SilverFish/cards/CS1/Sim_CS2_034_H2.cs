using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CS2_034_H2 : SimTemplate //* Fireblast
	{
		//Hero Power: Deal 1 damage.
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getHeroPowerDamage(1) : p.getEnemyHeroPowerDamage(1);
            p.minionGetDamageOrHeal(target, dmg);
        }
	}
}