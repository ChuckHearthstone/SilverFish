using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_LOOT_357l : SimTemplate //* Master Chest
	{
		// Deathrattle: Give your opponent a fantastic Treasure.
        // +Handled in DBs
		
        public override void onDeathrattle(Playfield p, Minion m)
        {
	        int cardsCount = (m.own) ? p.enemyAnzCards : p.owncards.Count;
			if (cardsCount > 9)
			{
				if (m.own) p.evaluatePenality -= 45;
				else p.evaluatePenality += 45;
			}
			
            p.drawACard(CardDB.cardName.unknown, !m.own);
        }
	}
}