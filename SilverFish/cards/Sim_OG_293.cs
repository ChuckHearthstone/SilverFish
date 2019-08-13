using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_OG_293 : SimTemplate //* Dark Arakkoa
	{
		//Taunt. Battlecry: Give your C'Thun +3/+3 (wherever it is).
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
			if (own.own)
			{
				p.anzOgOwnCThunHpBonus += 3;
				p.anzOgOwnCThunAngrBonus += 3;
			}
		}
	}
}