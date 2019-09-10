using System;
using System.Collections.Generic;
using System.Text;

namespace Chuck.SilverFish
{
	class Sim_DAL_350 : SimTemplate //* 水晶之力
	{
        //抉择：对一个随从造成2点伤害；或者恢复5点生命值。

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
			
			if (choice == 1 || (p.ownFandralStaghelm > 0 && ownplay))
			{
				int dmg = (ownplay) ? p.getSpellDamageDamage (2) : p.getEnemySpellDamageDamage (2);
				p.minionGetDamageOrHeal(target, dmg);

			}
			if (choice == 2 || (p.ownFandralStaghelm > 0 && ownplay))
			{
				int heal = (ownplay) ? p.getSpellHeal (5) : p.getEnemySpellHeal (5);
				p.minionGetDamageOrHeal(target, -heal);
			}



           
		}
	}
}