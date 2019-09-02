using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_DAL_558 : SimTemplate //* 大法师瓦格斯
	{
        //在你的回合结束时，施放你在本回合中施放过的一个法术（目标随机而定）。

        public override void onTurnEndsTrigger(Playfield p,  Minion triggerEffectMinion, bool turnEndOfOwner)
		{
			if (triggerEffectMinion.own == turnEndOfOwner)
			{
				//施放你在本回合中施放过的一个法术（目标随机而定）
			}



           
		}
	}
}