using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_018 : SimTemplate //* Flame Geyser
	{
		//Deal $2 damage. Add a 1/2 Elemental to your hand.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
            p.minionGetDamageOrHeal(target, dmg);
            p.drawACard(CardDB.cardName.flameelemental, ownplay, true);
		}
	}
}