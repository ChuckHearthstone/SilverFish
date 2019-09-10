using System;
using System.Collections.Generic;
using System.Text;

namespace Chuck.SilverFish
{
	class Sim_DAL_614 : SimTemplate //狗头人跟班
	{

//    战吼：造成2点伤害。
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            int dmg = 2;
            p.minionGetDamageOrHeal(target, dmg);
		}


	}
}