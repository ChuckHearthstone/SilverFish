using System;
using System.Collections.Generic;
using System.Text;

namespace Chuck.SilverFish
{
	class Sim_DAL_351ts : SimTemplate //* 远古祝福2
	{
        //使你的随从获得+1/+1。

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
			if (p.ownMinions.Count > 4) p.evaluatePenality -=20;
           p.allMinionOfASideGetBuffed(ownplay, 1, 1);
		}
	}
}