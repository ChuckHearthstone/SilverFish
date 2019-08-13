using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_AT_132_WARLOCK : SimTemplate //* Soul Tap
	{
		//Hero Power. Draw a card (without the Health penalty)

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardDB.cardName.unknown, ownplay);
        }
	}
}