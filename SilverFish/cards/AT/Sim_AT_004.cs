using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_AT_004 : SimTemplate //* Arcane Blast
	{
		//Deal 2 damage to a minion. This spell gets double bonus from Spell Damage.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(2 + p.spellpower) : p.getEnemySpellDamageDamage(2 + p.enemyspellpower);
            p.minionGetDamageOrHeal(target, dmg);
		}
	}
}