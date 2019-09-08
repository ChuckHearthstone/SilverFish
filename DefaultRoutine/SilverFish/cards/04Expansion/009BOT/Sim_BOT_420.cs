using System;
using System.Collections.Generic;
using System.Text;
using SilverFish.Enums;

namespace HREngine.Bots
{
	class Sim_BOT_420 : SimTemplate //* 植树造林
	{
        //召唤三个个2/2的树人。

		CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.EX1_158t);//树人

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
			int pos =(ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
			p.CallKid(kid, pos, ownplay, false);
			p.CallKid(kid, pos, ownplay);
			p.CallKid(kid, pos, ownplay);
			



           
		}
	}
}