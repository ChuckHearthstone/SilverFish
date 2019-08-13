using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_OG_113 : SimTemplate //* Darkshire Councilman
	{
		//After you summon a minion, gain +1 Attack.

        public override void onMinionWasSummoned(Playfield p, Minion m, Minion summonedMinion)
        {
            if (m.entitiyID != summonedMinion.entitiyID && m.own == summonedMinion.own)
            {
				p.minionGetBuffed(m, 1, 0);
            }
        }
    }
}