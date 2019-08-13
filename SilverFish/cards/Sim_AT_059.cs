using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_AT_059 : SimTemplate //* Brave Archer
	{
		//Inspire: If your hand is empty, deal 2 damage to the enemy hero.
		
		public override void onInspire(Playfield p, Minion m, bool own)
        {
			if (m.own == own)
			{
	            int cardsCount = (own) ? p.owncards.Count : p.enemyAnzCards;
				if (cardsCount <= 0)
				{
					p.minionGetDamageOrHeal(own ? p.enemyHero : p.ownHero, 2);
				}
			}
        }
	}
}