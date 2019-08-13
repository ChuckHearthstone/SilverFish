using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_920t1 : SimTemplate //* Queen Carnassa
	{
		//Battlecry: Shuffle 15 Raptors into your deck.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (own.own)
			{
				p.ownDeckSize += 15;
				p.evaluatePenality -= 20;
			}
		}
	}
}