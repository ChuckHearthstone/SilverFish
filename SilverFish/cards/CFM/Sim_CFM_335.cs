using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CFM_335 : SimTemplate //* Dispatch Kodo
	{
        // Battlecry: Deal damage equal to this minion's Attack.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (target != null) p.minionGetDamageOrHeal(target, m.Angr);
        }
	}
}