using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_KAR_033 : SimTemplate //* Book Wyrm
	{
		//Battlecry: If you're holding a Dragon, destroy an enemy minion with 3 Attack or less.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
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
				if(dragonInHand)
				{
					if (target!= null) p.minionGetDestroyed(target);
                }
			}
			else
			{
				if (p.enemyAnzCards >= 2)
				{
					if (target!= null) p.minionGetDestroyed(target);
                }					
			}
        }
    }
}