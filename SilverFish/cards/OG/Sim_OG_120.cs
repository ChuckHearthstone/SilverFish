using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_OG_120 : SimTemplate //* Anomalus
	{
		//Deathrattle: Deal 8 damage to all minions.
		
        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.allMinionsGetDamage(8);
        }
	}
}