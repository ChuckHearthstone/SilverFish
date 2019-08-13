using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_AT_051 : SimTemplate //* Elemental Destruction
	{
		//Deal 4-5 damage to all minions. Overload: (5)

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(4) : p.getEnemySpellDamageDamage(4);
            p.allMinionsGetDamage(dmg);
            if (ownplay) p.ueberladung += 5;
		}
	}
}