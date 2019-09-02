using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_BOT_219t : SimTemplate //* 更多手臂
	{
		//使一个随从获得+2/+2。

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionGetBuffed(target, 2, 2);
			
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            

		}
	}
}