using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_KAR_076 : SimTemplate //* Firelands Portal
	{
		//Deal 5 damage. Summon a random 5-Cost minion.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
			int dmg = (ownplay) ? p.getSpellDamageDamage(5) : p.getEnemySpellDamageDamage(5);
            p.minionGetDamageOrHeal(target, dmg);
			
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(p.getRandomCardForManaMinion(5), pos, ownplay);
		}
	}
}