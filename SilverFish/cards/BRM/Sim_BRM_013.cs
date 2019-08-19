using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_BRM_013 : SimTemplate //* Quick Shot
	{
		// Deal 3 damage. If your hand is empty, draw a card.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);
            p.minionGetDamageOrHeal(target, dmg);
			
			int cardsCount = (ownplay) ? p.owncards.Count : p.enemyAnzCards;
            if (cardsCount <= 0) p.drawACard(CardDB.cardName.unknown, ownplay);
		}
	}
}