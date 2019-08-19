using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_LOE_017 : SimTemplate //* Keeper of Uldaman
	{
		//Battlecry: Set a minion's Attack and Health to 3.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if(target != null)
			{
				p.minionSetAngrToX(target, 3);
				p.minionSetLifetoX(target, 3);
			}
		}
	}
}