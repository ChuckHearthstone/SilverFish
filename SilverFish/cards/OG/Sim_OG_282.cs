using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_OG_282 : SimTemplate //* Blade of C'Thun
	{
		//Battlecry: Destroy a minion. Add its Attack and Health to C'Thun's (wherever it is).
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if(target != null)
			{
                if (own.own) p.cthunGetBuffed(target.Angr, target.Hp, 0);
				p.minionGetDestroyed(target);
			}
		}
	}
}