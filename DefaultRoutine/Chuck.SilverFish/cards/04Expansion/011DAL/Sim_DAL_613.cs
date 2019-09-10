using System;
using System.Collections.Generic;
using System.Text;
using SilverFish.Enums;

namespace Chuck.SilverFish
{
	class Sim_DAL_613 : SimTemplate //* 无面跟班
	{
		//战吼：随机召唤一个法力值消耗为（2）点的随从。
		
		CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.CS2_121); // 2/2
				
		public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            List<Minion> list = (m.own) ? p.ownMinions : p.enemyMinions;
            int anz = list.Count;
            p.CallKid(kid, m.zonepos, m.own);
            if (anz < 7 && !list[m.zonepos].taunt)
            {
                list[m.zonepos].taunt = true;
                if (m.own) p.anzOwnTaunt++;
                else p.anzEnemyTaunt++;
            }
        }
	}
}