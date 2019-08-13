using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_957 : SimTemplate //* Direhorn Hatchling
	{
		//Taunt. Deathrattle: Shuffle a 6/9 Direhorn with Taunt into your deck.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (m.own) p.ownDeckSize++;
            else p.enemyDeckSize++;
        }
    }
}