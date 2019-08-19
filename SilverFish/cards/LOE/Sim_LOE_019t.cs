using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_LOE_019t : SimTemplate //* Map to the Golden Monkey
	{
		//Shuffle the Golden Monkey into your deck. Draw a card.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            if (ownplay)
			{
				p.ownDeckSize++;
				p.evaluatePenality -= 12;
			}
            else p.enemyDeckSize++;
			
			p.drawACard(CardDB.cardName.unknown, ownplay);
		}
	}
}