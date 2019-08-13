using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_LOOT_998l : SimTemplate //* Wondrous Wand
	{
		//Draw 3 cards. They cost (0).
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.drawACard(CardDB.cardName.unknown, ownplay);
            p.drawACard(CardDB.cardName.unknown, ownplay);
            p.drawACard(CardDB.cardName.unknown, ownplay);
			if (ownplay) p.evaluatePenality -= 20;
		}
	}
}