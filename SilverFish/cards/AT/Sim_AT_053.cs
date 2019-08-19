using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_AT_053 : SimTemplate //* Ancestral Knowledge
	{
		//Draw 2 Cards. Overload: (2)
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.drawACard(CardDB.cardName.unknown, ownplay);
            p.drawACard(CardDB.cardName.unknown, ownplay);
			if (ownplay) p.ueberladung += 2;
		}
	}
}