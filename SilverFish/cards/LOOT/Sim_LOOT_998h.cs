using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_LOOT_998h : SimTemplate //* Tolin's Goblet
	{
		//Draw a card. Fill your hand with copies of it.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.drawACard(CardDB.cardName.unknown, ownplay);
			if (ownplay) p.owncarddraw += 10 - p.owncards.Count;
		}
	}
}