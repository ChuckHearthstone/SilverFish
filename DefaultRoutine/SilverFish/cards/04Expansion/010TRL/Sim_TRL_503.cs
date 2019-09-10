using System;
using System.Collections.Generic;
using System.Text;
using SilverFish.Enums;

namespace Chuck.SilverFish
{
	class Sim_TRL_503 : SimTemplate //* 甲虫卵
	{
		//亡语：召唤三个1/1的甲虫。

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.TRL_503t);

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.CallKid(kid, m.zonepos-1, m.own);
            p.CallKid(kid, m.zonepos-1, m.own);
            p.CallKid(kid, m.zonepos-1, m.own);
        }
	}
}