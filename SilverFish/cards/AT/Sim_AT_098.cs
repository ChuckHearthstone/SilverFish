using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_AT_098 : SimTemplate //* Sideshow Spelleater
	{
		//Battlecry: Copy your opoonent's Hero Power.

		public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
		{
			if (m.own) p.ownHeroAblility = new Handmanager.Handcard(p.enemyHeroAblility);
            else p.enemyHeroAblility = new Handmanager.Handcard(p.ownHeroAblility);
		}
	}
}