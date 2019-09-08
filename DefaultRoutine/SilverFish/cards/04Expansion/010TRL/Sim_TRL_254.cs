using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_TRL_254 : SimTemplate //* 神灵印记
	{
        //抉择：使一个随从获得+2/+4和嘲讽；或者召唤两个3/2的迅猛龙。

		CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.CardIdEnum.TRL_254t);//迅猛龙

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
			
			if (choice == 1 || (p.ownFandralStaghelm > 0 && ownplay))
			{
				p.minionGetBuffed(target, 2, 2);
                if (!target.taunt)
                {
                   target.taunt = true;
                   if (target.own) p.anzOwnTaunt++;
                   else p.anzEnemyTaunt++;
                }

			}
			if (choice == 2 || (p.ownFandralStaghelm > 0 && ownplay))
			{
				int pos =(ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
			p.CallKid(kid, pos, ownplay, false);
			p.CallKid(kid, pos, ownplay);
			}



           
		}
	}
}