using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_817 : SimTemplate //* Tidal Surge
	{
		//Deal $4 damage to a minion. Restore #4 Health to your hero.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(4) : p.getEnemySpellDamageDamage(4);
            int heal = (ownplay) ? p.getSpellHeal(4) : p.getEnemySpellHeal(4);
			
            if (target != null) p.minionGetDamageOrHeal(target, dmg);
            p.minionGetDamageOrHeal(ownplay ? p.ownHero : p.enemyHero, -heal);
        }
    }
}