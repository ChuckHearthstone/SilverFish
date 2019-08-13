using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CFM_626 : SimTemplate //* Kabal Talonpriest
	{
		// Battlecry: Give a friendly minion +3 Health.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (target != null) p.minionGetBuffed(target, 0, 3);
        }
    }
}