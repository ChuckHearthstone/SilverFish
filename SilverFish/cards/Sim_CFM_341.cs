using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CFM_341 : SimTemplate //* Sergeant Sally
	{
		// Deathrattle: Deal damage equal to the minion's Attack to all enemy minions.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.allMinionOfASideGetDamage(!m.own, m.Angr);
        }
    }
}