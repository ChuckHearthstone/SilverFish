using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CFM_343 : SimTemplate //* Jade Behemoth
	{
		// Taunt. Battlecry: Summon a Jade Golem.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            p.callKid(p.getNextJadeGolem(m.own), m.zonepos, m.own);
        }
    }
}