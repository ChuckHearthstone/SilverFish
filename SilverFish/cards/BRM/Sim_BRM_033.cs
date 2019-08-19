using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_BRM_033 : SimTemplate //* Blackwing Technician
    {
        // Battlecry: If you're holding a Dragon, gain +1/+1.

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
				if(dragonInHand) p.minionGetBuffed(m, 1, 1);
			}
			else
			{
                if (p.enemyAnzCards >= 2) p.minionGetBuffed(m, 1, 1);
			}
        }
    }
}