using System;
using System.Collections.Generic;
using System.Text;
using SilverFish.Enums;

namespace Chuck.SilverFish
{
	class Sim_DAL_378 : SimTemplate //* 猛兽出笼
	{
        //双生法术：召唤一个5/5并具有突袭的双足飞龙。

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.DAL_378t1);//双足飞龙
        
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int pos = (ownplay)?  p.ownMinions.Count : p.enemyMinions.Count;
            p.CallKid(kid, pos, ownplay, false);

			p.drawACard(CardIdEnum.DAL_378ts, ownplay);
		}

	}
}