using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_AT_044 : SimTemplate //* Mulch
	{
		//Destroy a minion. Add a random minion to your opponent's hand.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
			p.minionGetDestroyed(target);
            p.drawACard(CardDB.cardName.unknown, !ownplay, true);
        }
    }
}