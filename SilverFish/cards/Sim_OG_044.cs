using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_OG_044 : SimTemplate //* Fandral Staghelm
	{
		//Your Choose One cards have both effects combine.

        public override void onAuraStarts(Playfield p, Minion own)
        {
            if (own.own) p.anzOwnFandralStaghelm++;
        }

        public override void onAuraEnds(Playfield p, Minion m)
        {
            if (m.own) p.anzOwnFandralStaghelm--;
        }
	}
}