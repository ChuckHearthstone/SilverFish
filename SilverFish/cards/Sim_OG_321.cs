using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_OG_321 : SimTemplate //* Crazed Worshipper
	{
		//Taunt. Whenever this minion takes damage, give your C'Thun +1/+1 (wherever it is).

        public override void onMinionGotDmgTrigger(Playfield p, Minion m, int anzOwnMinionsGotDmg, int anzEnemyMinionsGotDmg, int anzOwnHeroGotDmg, int anzEnemyHeroGotDmg)
        {
            if (m.anzGotDmg > 0)
            {
                int tmp = m.anzGotDmg;
                m.anzGotDmg = 0;
                p.cthunGetBuffed(tmp, tmp, 0);
            }
        }
	}
}