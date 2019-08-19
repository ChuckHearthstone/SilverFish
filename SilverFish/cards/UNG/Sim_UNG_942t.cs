using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_942t : SimTemplate //* Megafin
	{
		//Battlecry: Fill your hand with random Murlocs.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
			if (own.own)
			{
				p.owncarddraw += 10 - p.owncards.Count;
			}
		}
	}
}