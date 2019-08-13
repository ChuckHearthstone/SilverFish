using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_211b : SimTemplate //* Invocation of Water
	{
		//Restore 12 Health to your hero.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int heal = (ownplay) ? p.getSpellHeal(12) : p.getEnemySpellHeal(12);
			p.minionGetDamageOrHeal(ownplay ? p.ownHero : p.enemyHero, -heal);
		}
	}
}