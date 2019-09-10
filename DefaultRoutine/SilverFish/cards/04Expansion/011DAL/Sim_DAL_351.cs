using System;
using System.Collections.Generic;
using System.Text;
using SilverFish.Enums;

namespace Chuck.SilverFish
{
	class Sim_DAL_351 : SimTemplate //* 远古祝福
	{
        //双生法术：使你的随从获得+1/+1。

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
           if (p.ownMinions.Count < 3) p.evaluatePenality +=30;
		   p.allMinionOfASideGetBuffed(ownplay, 1, 1);
		   p.drawACard(CardIdEnum.DAL_351ts, ownplay);
		}
	}
}