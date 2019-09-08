using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_DAL_378ts : SimTemplate //* 猛兽出笼2
	{
        //召唤一个5/5并具有突袭的双足飞龙。

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.CardIdEnum.DAL_378t1);//双足飞龙
        
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int pos = (ownplay)?  p.ownMinions.Count : p.enemyMinions.Count;
            p.CallKid(kid, pos, ownplay, false);

		}

	}
}