using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_AT_063 : SimTemplate //* Acidmaw
	{
		//Whenever another minion takes damage, destroy it.

        public override void onAuraStarts(Playfield p, Minion own)
		{
            p.anzAcidmaw++;
		}

        public override void onAuraEnds(Playfield p, Minion m)
        {
            p.anzAcidmaw--;
		}
	}
}