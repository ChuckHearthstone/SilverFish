using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CS2_227 : SimTemplate //* Venture Co. Mercenary
	{
        //Your minions cost (3) more.

        public override void onAuraStarts(Playfield p, Minion own)
		{
           if(own.own) p.ownMinionsCostMore += 3;
		}

        public override void onAuraEnds(Playfield p, Minion own)
        {
           if(own.own) p.ownMinionsCostMore -= 3;
        }
	}
}