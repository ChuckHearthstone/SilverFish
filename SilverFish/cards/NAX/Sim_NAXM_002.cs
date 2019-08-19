using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_NAXM_002 : SimTemplate //* Skeletal Smith
	{
		// Deathrattle: Destroy your opponent's weapon.
		
		public override void onDeathrattle(Playfield p, Minion m)
		{
            p.lowerWeaponDurability(1000, !m.own);
		}
	}
}