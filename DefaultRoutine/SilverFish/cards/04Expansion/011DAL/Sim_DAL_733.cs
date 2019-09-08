using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_DAL_733 : SimTemplate //* 守卫梦境之路
	{
        //召唤两个1/2并具有吸血的树妖。

		CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.DAL_733t);//水晶树妖

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
			int pos =(ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
			p.CallKid(kid, pos, ownplay, false);
			p.CallKid(kid, pos, ownplay);
		}
	}
}