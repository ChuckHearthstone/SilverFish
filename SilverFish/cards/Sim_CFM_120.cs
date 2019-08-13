using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CFM_120 : SimTemplate //* Mistress of Mixtures
	{
		// Deathrattle: Restore 4 Health to both players.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            int heal = (m.own) ? p.getMinionHeal(4) : p.getEnemyMinionHeal(4);
            p.minionGetDamageOrHeal(p.ownHero, -heal);
            p.minionGetDamageOrHeal(p.enemyHero, -heal);
        }
    }
}