using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_NAX14_04 : SimTemplate //* purecold
	{
		//Deal 8 damage to the enemy hero, and and Freeze it.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(8) : p.getEnemySpellDamageDamage(8);
			target = ownplay ? p.enemyHero : p.ownHero;
            p.minionGetDamageOrHeal(target, dmg, true);
            p.minionGetFrozen(target);
        }
	}
}