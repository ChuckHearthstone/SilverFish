using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_DAL_400 : SimTemplate //* 怪盗布缆鼠
	{
		//战吼：将一张跟班牌置入你的手牌。

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
           
			p.drawACard(CardDB.CardName.unknown, own.own, true);
                        
           
		}
	}
}