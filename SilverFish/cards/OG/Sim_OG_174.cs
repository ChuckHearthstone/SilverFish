using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_OG_174 : SimTemplate //* Faceless Shambler
	{
		//Battlecry: Copy a friendly minion's Attack and Health.
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (target != null)
			{
				own.Hp = target.Hp;
				own.Angr = target.Angr;
			}
		}
	}
}