using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CFM_691 : SimTemplate //* Jade Swarmer
	{
		// Stealth, Deathrattle: Summon a Jade Golem.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.CallKid(p.getNextJadeGolem(m.own), m.zonepos - 1, m.own);
        }
    }
}