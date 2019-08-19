using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_AT_103 : SimTemplate //* North Sea Kraken
	{
		//Battlecry: Deal 4 damage.
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            int dmg = 4;
            p.minionGetDamageOrHeal(target, dmg);
		}
	}
}