using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_NAX1_05 : SimTemplate//* Locust Swarm
    {
        //Deal $3 damage to all enemy minions. Restore #3 Health to your hero.
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay)? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);
            int heal = (ownplay) ? p.getSpellHeal(3) : p.getEnemySpellHeal(3) ;
            if (ownplay)
            {
                p.minionGetDamageOrHeal(p.ownHero, -heal);
                p.minionGetDamageOrHeal(p.enemyHero, dmg);
                foreach (Minion m in p.enemyMinions)
                {
                    p.minionGetDamageOrHeal(m, dmg);
                }
            }
            else 
            {
                p.minionGetDamageOrHeal(p.enemyHero, -heal);
                p.minionGetDamageOrHeal(p.ownHero, dmg);
                foreach (Minion m in p.ownMinions)
                {
                    p.minionGetDamageOrHeal(m, dmg);
                }
            }
        }

    }
}
