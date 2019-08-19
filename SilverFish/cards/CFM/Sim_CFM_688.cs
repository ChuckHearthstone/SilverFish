using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CFM_688 : SimTemplate //* Spiked Hogrider
	{
		// Battlecry: If an enemy minion has Taunt, gain Charge.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            int anz = m.own ? p.anzEnemyTaunt : p.anzOwnTaunt;
            if (anz > 0) p.minionGetCharge(m);
        }
    }
}