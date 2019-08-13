using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CFM_816 : SimTemplate //* Virmen Sensei
	{
		// Battlecry: Give a friendly Beast +2/+2.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (target != null) p.minionGetBuffed(target, 2, 2);
        }
    }
}