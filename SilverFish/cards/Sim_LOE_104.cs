using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_LOE_104 : SimTemplate //* Entomb
	{
		//Choose an enemy minion. Shuffle it into your deck.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionReturnToDeck(target, ownplay);
		}
	}
}