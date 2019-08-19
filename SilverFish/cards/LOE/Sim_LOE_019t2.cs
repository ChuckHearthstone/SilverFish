using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_LOE_019t2 : SimTemplate //* Golden Monkey
	{
		//Taunt. Battlecry: Replace your hand and deck with Legendary minions.
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
			int bonus = 0;
            if (own.own) bonus = -5 * p.owncards.Count;
            else bonus = 5 * p.enemyAnzCards;
			p.evaluatePenality += bonus;
		}
	}
}