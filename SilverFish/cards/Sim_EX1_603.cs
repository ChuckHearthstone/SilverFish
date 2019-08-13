using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_EX1_603 : SimTemplate //* Cruel Taskmaster
	{
        // Battlecry: Deal 1 damage to a minion and give it +2 

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (target != null)
            {
                p.minionGetDamageOrHeal(target, 1);
                p.minionGetBuffed(target, 2, 0);
            }
		}
	}
}