using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_KAR_006 : SimTemplate //* Cloaked Huntress
	{
		//Your Secrets cost (0).

		public override void onAuraStarts(Playfield p, Minion m)
		{
            if (m.own) p.anzOwnCloakedHuntress++;
		}

        public override void onAuraEnds(Playfield p, Minion m)
        {
            if (m.own) p.anzOwnCloakedHuntress--;
        }
	}
}