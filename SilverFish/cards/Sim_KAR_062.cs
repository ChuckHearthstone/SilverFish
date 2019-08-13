using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_KAR_062 : SimTemplate //* Netherspite Historian
	{
		//Battlecry: If you're holding a Dragon, Discover a Dragon.
		
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
			if(own.own)
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
					p.drawACard(CardDB.cardName.drakonidcrusher, own.own, true);
                }
			}
			else
			{
				if (p.enemyAnzCards >= 2)
				{
					p.drawACard(CardDB.cardName.drakonidcrusher, own.own, true);
                }					
			}
        }
    }
}