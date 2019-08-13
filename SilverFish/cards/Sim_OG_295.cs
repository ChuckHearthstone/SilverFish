using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_OG_295 : SimTemplate //* Cult Apothecary
	{
		//Battlecry: For each enemy minion, restore 2 Health to your hero.
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
			if (own.own) p.minionGetDamageOrHeal(p.ownHero, -p.getMinionHeal(2 * p.enemyMinions.Count));
			else p.minionGetDamageOrHeal(p.enemyHero, -p.getEnemyMinionHeal(2 * p.ownMinions.Count));
        }
    }
}