using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_KAR_094 : SimTemplate //* Deadly Fork
	{
		//Deathrattle: Add a 3/2 weapon to your hand.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(CardDB.cardName.sharpfork, m.own, true);
        }
    }
}