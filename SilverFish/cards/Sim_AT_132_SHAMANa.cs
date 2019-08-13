using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_AT_132_SHAMANa : SimTemplate //* Healing Totem
	{
		//At the end of your turn, restore 1 Health to all friendly minions.

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                int heal = (triggerEffectMinion.own) ? p.getMinionHeal(1) : p.getEnemyMinionHeal(1);
                p.allMinionOfASideGetDamage(turnEndOfOwner, -heal);
            }
        }
	}
}