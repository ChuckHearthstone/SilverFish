using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_848 : SimTemplate //* Primordial Drake
	{
		//Taunt Battlecry: Deal 2 damage to all other minions.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.allMinionsGetDamage(2, own.entitiyID);
        }
	}
}