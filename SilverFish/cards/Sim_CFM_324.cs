using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CFM_324 : SimTemplate //* White Eyes
	{
		// Taunt. Deathrattle: Shuffle 'The Storm Guardian' into your deck.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (m.own) p.ownDeckSize++;
            else p.enemyDeckSize++;
        }
    }
}