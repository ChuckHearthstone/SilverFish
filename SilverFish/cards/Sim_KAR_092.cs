using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_KAR_092 : SimTemplate //* Medivh's Valet
	{
		//Battlecry: If you control a Secret, deal 3 damage.
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (target != null) p.minionGetDamageOrHeal(target, 3);
		}
	}
}