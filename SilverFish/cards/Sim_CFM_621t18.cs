using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CFM_621t18 : SimTemplate //* Felbloom
	{
		// Deal $4 damage to all minions.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(4) : p.getEnemySpellDamageDamage(4);
            p.allMinionsGetDamage(dmg);
        }
    }
}