using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CFM_647 : SimTemplate //* Blowgill Sniper
	{
		// Battlecry: Deal 1 damage.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.minionGetDamageOrHeal(target, 1);
        }
    }
}