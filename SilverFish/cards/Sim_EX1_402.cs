using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_402 : SimTemplate //* armorsmith
	{
    // Whenever a friendly minion takes damage, gain 1 Armor.

        public override void onMinionGotDmgTrigger(Playfield p, Minion m, int anzOwnMinionsGotDmg, int anzEnemyMinionsGotDmg, int anzOwnHeroGotDmg, int anzEnemyHeroGotDmg)
        {
            if (m.own)
            {
                for (int i = 0; i < anzOwnMinionsGotDmg - anzOwnHeroGotDmg; i++)
                {
					p.minionGetArmor(p.ownHero, 1);
                }
            }
            else
            {
                for (int i = 0; i < anzEnemyMinionsGotDmg - anzEnemyHeroGotDmg; i++)
                {
                    p.minionGetArmor(p.enemyHero, 1);
                }
            }
        }
	}
}