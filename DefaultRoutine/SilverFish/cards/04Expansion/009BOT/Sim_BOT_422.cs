using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_BOT_422 : SimTemplate //* 牛头人园丁
    {
        //抉择：使你的所有其他随从获得+1/+1；或者召唤两个2/2的树人。

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.EX1_573t); //special treant

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (choice == 1 || (p.ownFandralStaghelm > 0 && own.own))
            {
                if (p.ownMinions.Count < 3) p.evaluatePenality +=30;
                List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;
                foreach (Minion m in temp)
                {
                    if (own.entitiyID != m.entitiyID) p.minionGetBuffed(m, 1, 1);
                }
            }
            if (choice == 2 || (p.ownFandralStaghelm > 0 && own.own))
            {
                p.CallKid(kid, own.zonepos, own.own, false);
                p.CallKid(kid, own.zonepos - 1, own.own);
            }
		}
	}
}