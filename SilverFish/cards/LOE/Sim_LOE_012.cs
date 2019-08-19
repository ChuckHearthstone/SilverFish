using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_LOE_012 : SimTemplate //* Tomb Pillager
	{
		//Deathrattle: Put a Coin into your hand.
		
        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(CardDB.cardName.thecoin, m.own);
        }
    }
}