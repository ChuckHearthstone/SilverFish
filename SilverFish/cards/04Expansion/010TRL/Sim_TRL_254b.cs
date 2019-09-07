using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_TRL_254b : SimTemplate //* 迅猛龙群
	{
        //召唤两个3/2的迅猛龙

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.TRL_254t);//迅猛龙

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
			int pos =(ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
			p.CallKid(kid, pos, ownplay, false);
			p.CallKid(kid, pos, ownplay);
		}
	}
}