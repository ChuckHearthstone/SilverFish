using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_AT_057 : SimTemplate //* Stablemaster
	{
		//Battlecry: Give a friendly Beast Immune this Turn.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (target != null) target.immune = true;
		}
	}
}