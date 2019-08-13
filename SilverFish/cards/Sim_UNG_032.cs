using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_032 : SimTemplate //* Crystalline Oracle
	{
		//Deathrattle: Copy a card from your opponent's deck and add it to your hand.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(CardDB.cardName.unknown, m.own, true);
        }
	}
}