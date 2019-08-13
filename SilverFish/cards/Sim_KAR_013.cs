using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_KAR_013 : SimTemplate //* Purify
	{
		//Silence a friendly minion. Draw a card.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionGetSilenced(target);
            p.drawACard(CardDB.cardName.unknown, ownplay);
		}
	}
}