using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_LOE_006 : SimTemplate //* Museum Curator
	{
		//Battlecry: Discover a Deathrattle card.
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.drawACard(CardDB.cardName.lepergnome, own.own, true);
		}
	}
}