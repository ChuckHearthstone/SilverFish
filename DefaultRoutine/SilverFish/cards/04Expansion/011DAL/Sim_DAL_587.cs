using System;
using System.Collections.Generic;
using System.Text;
using SilverFish.Enums;

namespace HREngine.Bots
{
	class Sim_DAL_587 : SimTemplate //* 闪光蝴蝶
	{

//    亡语：随机将一张猎人法术牌置入你的手牌。
        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(CardName.unknown, m.own);
        }

	}
}