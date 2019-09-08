using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_BOT_219 : SimTemplate //* 增生手臂
	{
		//使一个随从获得+2/+2。将一张可使一个随从获得+2/+2的“更多手臂”置入你的手牌。
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionGetBuffed(target, 2, 2);
			
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            
			p.drawACard(CardDB.CardIdEnum.BOT_219t, ownplay);
		}
	}
}