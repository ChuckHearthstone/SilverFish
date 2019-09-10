using System;
using System.Collections.Generic;
using System.Text;

namespace Chuck.SilverFish
{
	class Sim_DAL_350a : SimTemplate //* 利刺荆棘
	{
        //对一个随从造成2点伤害。

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
			
			
				int dmg = (ownplay) ? p.getSpellDamageDamage (2) : p.getEnemySpellDamageDamage (2);
				p.minionGetDamageOrHeal(target, dmg);

			


           
		}
	}
}