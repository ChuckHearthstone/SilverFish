using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_AT_040 : SimTemplate //* Wildwalker
	{
		//Battlecry: Give a friendly Beast +3 Health.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (target != null)
            {
                p.minionGetBuffed(target, 0, 3);
            }
		}
	}
}