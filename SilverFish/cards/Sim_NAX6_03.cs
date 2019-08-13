using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_NAX6_03 : SimTemplate //* Deathbloom
	{
		// Deal $5 damage to a minion. Summon a Spore.
		
		CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.NAX6_03t);//Spore

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
			int dmg = (ownplay) ? p.getSpellDamageDamage(5) : p.getEnemySpellDamageDamage(5);
            p.minionGetDamageOrHeal(target, dmg);
			
            int place = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(kid, place, ownplay);
		}
	}
}