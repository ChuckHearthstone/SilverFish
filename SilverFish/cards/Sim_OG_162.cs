using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_OG_162 : SimTemplate //* Disciple of C'Thun
	{
		//Battlecry: Deal 2 damage. Give your C'Thun +2/+2 (wherever it is)
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.minionGetDamageOrHeal(target, 2);
            if (own.own) p.cthunGetBuffed(2, 2, 0);
		}
	}
}