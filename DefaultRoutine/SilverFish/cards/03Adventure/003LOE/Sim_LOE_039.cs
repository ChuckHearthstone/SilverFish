using System.Collections.Generic;
using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._03Adventure._003LOE
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
					p.drawACard(CardName.spidertank, own.own, true);
					break;
				}
            }
		}
	}
}