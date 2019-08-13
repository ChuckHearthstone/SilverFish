using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_LOE_039 : SimTemplate //* Gorillabot A-3
	{
		//Battlecry: If you control another Mech, Discover a Mech.
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
                if (m.entitiyID == own.entitiyID) continue;
                if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MECHANICAL)
				{
					p.drawACard(CardDB.cardName.spidertank, own.own, true);
					break;
				}
            }
		}
	}
}