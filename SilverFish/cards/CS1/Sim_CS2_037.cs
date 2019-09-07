using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_CS2_037 : SimTemplate //* Frost Shock
	{
        //Deal $1 damage to an enemy character and Freeze it.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(1) : p.getEnemySpellDamageDamage(1);
            p.minionGetFrozen(target);
            p.minionGetDamageOrHeal(target, dmg);
		}
	}
}