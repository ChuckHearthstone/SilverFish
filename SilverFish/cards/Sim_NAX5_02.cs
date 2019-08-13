using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_NAX5_02 : SimTemplate //* Eruption
	{
		//Hero Power: Deal 2 damage to the left-most enemy 
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            List<Minion> temp = (ownplay) ? p.enemyMinions : p.ownMinions;
            if (temp.Count < 1) return;
            else
			{
				int dmg = (ownplay) ? p.getHeroPowerDamage(2) : p.getEnemyHeroPowerDamage(2);
				target = temp[0];
				foreach (Minion m in temp)
				{
					if (m.zonepos < target.zonepos) target = m;
				}
				p.minionGetDamageOrHeal(target, dmg);
			}
		}
	}
}