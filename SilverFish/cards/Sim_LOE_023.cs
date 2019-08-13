using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_LOE_023 : SimTemplate //* Dark Peddler
	{
		//Battlecry: Discover a (1)-cost card.
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.drawACard(CardDB.cardName.lepergnome, own.own, true);
		}
	}
}