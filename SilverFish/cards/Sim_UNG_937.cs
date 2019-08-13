using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_937 : SimTemplate //* Primalfin Lookout
	{
		//Battlecry: If you control another Murloc, Discover a Murloc.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
                if (m.entitiyID == own.entitiyID) continue;
                if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MURLOC)
				{
					p.drawACard(CardDB.cardName.bluegillwarrior, own.own, true);
					break;
				}
            }
		}
	}
}