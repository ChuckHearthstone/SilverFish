using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_955 : SimTemplate //* Meteor
	{
		//Deal $15 damage to a minion and $3 damage to adjacent ones.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmgMain = (ownplay) ? p.getSpellDamageDamage(15) : p.getEnemySpellDamageDamage(15);
            int dmgAdj = (ownplay) ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);
            List<Minion> temp = (target.own) ? p.ownMinions : p.enemyMinions;
            p.minionGetDamageOrHeal(target, dmgMain);
            foreach (Minion m in temp)
            {
                if (m.zonepos + 1 == target.zonepos || m.zonepos - 1 == target.zonepos) p.minionGetDamageOrHeal(m, dmgAdj);
            }
		}
	}
}