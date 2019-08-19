using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_025 : SimTemplate //* Volcano
	{
		//Deal $15 damage randomly split among all minions. Overload: (2)

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(15) : p.getEnemySpellDamageDamage(15);
            
            List<Minion> temp = new List<Minion>(p.ownMinions);
            temp.AddRange(p.enemyMinions);

            for (int i = 0; i < dmg; i++)
            {
                int surviving = 0;
                foreach (Minion m in temp.ToArray())
                {
                    if (m.Hp < 1) continue;
                    p.minionGetDamageOrHeal(m, 1);
                    i++;
                    surviving++;
                    if (i >= dmg) break;
                }
                if (surviving == 0) break;
            }

            if (ownplay) p.ueberladung += 2;
        }
    }
}