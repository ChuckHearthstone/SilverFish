using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_OG_188 : SimTemplate //* Klaxxi Amber-Weaver
	{
		//Battlecry: If your C'Thun has at least 10 Attack, gain +5 Health.
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (own.own)
            {
                if (p.anzOgOwnCThunAngrBonus + 6 > 9) p.minionGetBuffed(own, 0, 5);
                else p.evaluatePenality += 5;
            }
		}
	}
}