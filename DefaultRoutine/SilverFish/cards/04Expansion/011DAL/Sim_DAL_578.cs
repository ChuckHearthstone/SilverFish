using System;
using System.Collections.Generic;
using System.Text;
using SilverFish.Enums;

namespace HREngine.Bots
{
	class Sim_DAL_578 : SimTemplate //* 创世之力
	{
		//发现一张法力值消耗为（6）的随从牌。召唤它的两个复制。

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            if (p.ownHeroHasDirectLethal()) p.CallKid(CardDB.Instance.getCardData(CardName.icehowl), pos, ownplay, false);
            else p.CallKid(CardDB.Instance.getCardData(CardName.frostgiant), pos, ownplay, false);
        }
    }
}