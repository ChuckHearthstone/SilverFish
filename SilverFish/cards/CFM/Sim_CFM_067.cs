using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CFM_067 : SimTemplate //* Hozen Healer
	{
		// Battlecry: Restore a minion to full Health.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (target != null)
            {
                int heal = (m.own) ? p.getMinionHeal(target.maxHp - target.HealthPoints) : p.getEnemyMinionHeal(target.maxHp - target.HealthPoints);
                p.minionGetDamageOrHeal(target, -heal, true);
            }
        }
    }
}