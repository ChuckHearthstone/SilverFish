using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_AT_030 : SimTemplate //* Undercity Valiant
	{
		//Combo: deal 1 damage.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (p.cardsPlayedThisTurn >= 1 && target != null)
            {
                p.minionGetDamageOrHeal(target, 1);
            }
		}
	}
}