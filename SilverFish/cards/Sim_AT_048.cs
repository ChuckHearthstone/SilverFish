using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_AT_048 : SimTemplate //* Healing Wave
	{
		//Restore 7 Health. Reveal a minion in each deck. If yours costs more, Restore 14 instead.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int heal = (ownplay) ? p.getSpellHeal(14) : p.getEnemySpellHeal(14);//optimistic
            p.minionGetDamageOrHeal(target, -heal);            
		}
	}
}