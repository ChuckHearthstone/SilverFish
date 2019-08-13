using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_OG_073 : SimTemplate //* Thistle Tea
	{
		//Draw a card. Add 2 extra copies of it to your hand.
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardDB.cardName.unknown, ownplay);
            p.drawACard(CardDB.cardName.unknown, ownplay, true);
            p.drawACard(CardDB.cardName.unknown, ownplay, true);
        }
    }
}
