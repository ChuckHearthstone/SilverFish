using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_OG_147 : SimTemplate //* Corrupted Healbot
	{
		//Deathrattle: Restore 8 Health to the enemy hero.
		
        public override void onDeathrattle(Playfield p, Minion m)
        {
            int heal = (m.own) ? p.getMinionHeal(8) : p.getEnemyMinionHeal(8);

            p.minionGetDamageOrHeal(m.own ? p.enemyHero : p.ownHero, -heal);
        }
    }
}