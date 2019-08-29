using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_050 : SimTemplate //Bouncing Blade
    {

        //   Deal $1 damage to a random minion. Repeat until a minion dies.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(1) : p.getEnemySpellDamageDamage(1);

            int minHp = 100000;
            foreach (Minion m in p.ownMinions)
            {
                if (m.HealthPoints < minHp) minHp = m.HealthPoints;
            }
            foreach (Minion m in p.enemyMinions)
            {
                if (m.HealthPoints < minHp) minHp = m.HealthPoints;
            }

            int dmgdone = (int)Math.Ceiling((double)minHp / (double)dmg) * dmg;

            p.allMinionsGetDamage(dmgdone);
        }


    }

}