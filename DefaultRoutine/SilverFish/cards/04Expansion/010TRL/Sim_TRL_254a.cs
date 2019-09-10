using System;
using System.Collections.Generic;
using System.Text;

namespace Chuck.SilverFish
{
	class Sim_TRL_254a : SimTemplate //* 贡克的坚韧
	{
        //使一个随从获得+2/+4和嘲讽。

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
			p.minionGetBuffed(target, 2, 2);
            if (!target.taunt)
            {
                target.taunt = true;
                if (target.own) p.anzOwnTaunt++;
                else p.anzEnemyTaunt++;
            }
		}
	}
}