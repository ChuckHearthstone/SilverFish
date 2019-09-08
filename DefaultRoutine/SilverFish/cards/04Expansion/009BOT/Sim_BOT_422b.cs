using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_BOT_422b : SimTemplate //* 新生幼苗
	{
        //召唤两个2/2的树人。

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.EX1_573t); //special treant
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.CallKid(kid, pos, ownplay, false);
            p.CallKid(kid, pos, ownplay);
		}

	}
}