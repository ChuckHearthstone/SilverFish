using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_OG_072 : SimTemplate //* Journey Below
	{
		//Discover a Deathrattle card
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.drawACard(CardDB.cardName.lepergnome, ownplay, true);
		}
	}
}