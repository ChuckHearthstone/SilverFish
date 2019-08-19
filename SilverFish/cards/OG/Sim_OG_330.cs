using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_OG_330 : SimTemplate //* Undercity Huckster
	{
		//Deathrattle: Add a random class card to your hand (from your opponent's class).

		public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(CardDB.cardName.unknown, m.own, true);
        }
    }
}