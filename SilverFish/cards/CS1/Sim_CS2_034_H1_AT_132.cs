using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CS2_034_H1_AT_132 : SimTemplate //* Fireblast Rank 2
	{
		//Hero Power: Deal 2 damage.
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getHeroPowerDamage(2) : p.getEnemyHeroPowerDamage(2);
            p.minionGetDamageOrHeal(target, dmg);
        }
	}
}