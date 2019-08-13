using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_CS2_012 : SimTemplate // Swipe
	{
        // Deal $4 damage to an enemy and $1 damage to all other enemies.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(4) : p.getEnemySpellDamageDamage(4);
            int dmg1 = (ownplay)? p.getSpellDamageDamage(1) : p.getEnemySpellDamageDamage(1);

            List<Minion> temp = (ownplay) ? p.enemyMinions : p.ownMinions;
            p.minionGetDamageOrHeal(target, dmg);
            foreach (Minion m in temp)
            {
                if (m.entitiyID != target.entitiyID)
                {
                    m.getDamageOrHeal(dmg1, p, true, false); // isMinionAttack=true because it is extra damage (we calc clear lostDamage)
                }
            }
            if (ownplay)
            {
                if (p.enemyHero.entitiyID != target.entitiyID)
                {
                    p.minionGetDamageOrHeal(p.enemyHero, dmg1);
                }
                if (Hrtprozis.Instance.enemyMinions.Count > p.enemyMinions.Count) p.lostDamage += dmg1;
            }
            else
            {
                if (p.ownHero.entitiyID != target.entitiyID)
                {
                    p.minionGetDamageOrHeal(p.ownHero, dmg1);
                }
                if (Hrtprozis.Instance.ownMinions.Count > p.ownMinions.Count) p.lostDamage += dmg1;
            }
		}
	}
}