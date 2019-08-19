using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_029 : SimTemplate //* Shadow Visions
	{
		//Discover a copy of a spell in your deck.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.drawACard(CardDB.cardName.shadowworddeath, ownplay, true);
            p.drawACard(CardDB.cardName.holynova, ownplay, true);
			p.owncarddraw--;
		}
	}
}