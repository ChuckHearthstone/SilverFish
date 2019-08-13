using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_205 : SimTemplate //* Glacial Shard
	{
		//Battlecry: Freeze an enemy.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (target != null) p.minionGetFrozen(target);
		}
	}
}