using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_KAR_075 : SimTemplate //* Moonglade Portal
	{
		//Restore 6 Health. Summon a random 6-Cost minion.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int heal = (ownplay) ? p.getSpellHeal(6) : p.getEnemySpellHeal(6);
            p.minionGetDamageOrHeal(target, -heal);
			
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;			
            p.callKid(p.getRandomCardForManaMinion(6), pos, ownplay, false);
		}
	}
}