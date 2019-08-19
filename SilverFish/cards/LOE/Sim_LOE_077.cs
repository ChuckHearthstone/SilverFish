using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_LOE_077 : SimTemplate //* Brann Bronzebeard
	{
		//Your Battlecries trigger twice.
		
        public override void onAuraStarts(Playfield p, Minion own)
		{
            if (own.own) p.ownBrannBronzebeard++;
            else p.enemyBrannBronzebeard++;
		}

        public override void onAuraEnds(Playfield p, Minion m)
        {
            if (m.own) p.ownBrannBronzebeard--;
            else p.enemyBrannBronzebeard--;
        }
	}
}