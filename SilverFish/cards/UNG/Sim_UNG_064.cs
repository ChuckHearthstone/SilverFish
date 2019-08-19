using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_064 : SimTemplate //* Vilespine Slayer
	{
		//Combo: Destroy a minion.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (p.cardsPlayedThisTurn >= 1 && target != null && own.own)
            {
                p.minionGetDestroyed(target);
            }
		}
	}
}