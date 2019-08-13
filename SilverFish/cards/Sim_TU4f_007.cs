using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_TU4f_007 : SimTemplate //* Crazy Monkey
	{
		//Battlecry:: Throw Bananas.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.drawACard(CardDB.cardName.bananas, !own.own, true);
            if (own.own)
            {
                p.enemycarddraw -= 1;
            }
		}
	}
}