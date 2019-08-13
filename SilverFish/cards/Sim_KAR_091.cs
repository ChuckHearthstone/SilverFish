using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_KAR_091 : SimTemplate //* Ironforge Portal
	{
		//Gain 4 Armor. Summon a random 4-Cost minion.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionGetArmor(ownplay ? p.ownHero : p.enemyHero, 4);	
			
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(p.getRandomCardForManaMinion(4), pos, ownplay);
		}
	}
}