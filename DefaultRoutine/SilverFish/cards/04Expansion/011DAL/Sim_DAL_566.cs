using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_DAL_566 : SimTemplate //* 古怪的铭文师
	{
		//亡语：召唤四个1/1的复仇卷轴。

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.DAL_566t);

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.CallKid(kid, m.zonepos-1, m.own);
            p.CallKid(kid, m.zonepos-1, m.own);
            p.CallKid(kid, m.zonepos-1, m.own);
            p.CallKid(kid, m.zonepos-1, m.own);
        }
	}
}