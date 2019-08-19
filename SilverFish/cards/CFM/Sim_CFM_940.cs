using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CFM_940 : SimTemplate //* I Know a Guy
	{
		// Discover a Taunt minion.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardDB.cardName.pompousthespian, ownplay, true);
        }
    }
}