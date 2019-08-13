using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_AT_123 : SimTemplate //* Chillmaw
	{
		//Taunt Deathrattle: If you're holding a Dragon, deal 3 damage to all minions.

		public override void onDeathrattle(Playfield p, Minion m)
        {
			if(m.own)
			{
				bool dragonInHand = false;
				foreach (Handmanager.Handcard hc in p.owncards)
				{
					if ((TAG_RACE)hc.card.race == TAG_RACE.DRAGON)
					{
						dragonInHand = true;
						break;
					}
				}
				if(dragonInHand) p.allMinionsGetDamage(3);
			}
			else
			{
				if (p.enemyAnzCards >= 1) p.allMinionsGetDamage(3);
			}
        }
    }
}