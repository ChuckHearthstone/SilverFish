using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_DAL_413 : SimTemplate //* 怪盗征募员
	{
		//亡语：将一张跟班牌置入你的手牌。

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(CardDB.cardName.unknown, m.own, true);
        }
	}
}