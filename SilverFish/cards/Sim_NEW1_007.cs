using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_NEW1_007 : SimTemplate //* Starfall
	{
        // Choose One - Deal $5 damage to a minion; or $2 damage to all enemy minions.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            if (choice == 1 || (target != null && p.ownFandralStaghelm > 0 && ownplay))
            {
                int dmg = (ownplay) ? p.getSpellDamageDamage(5) : p.getEnemySpellDamageDamage(5);
                p.minionGetDamageOrHeal(target, dmg);
            }
            if (choice == 2 || (p.ownFandralStaghelm > 0 && ownplay))
            {
                int damage = (ownplay) ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
                p.allMinionOfASideGetDamage(!ownplay, damage);
            }
		}
	}
}