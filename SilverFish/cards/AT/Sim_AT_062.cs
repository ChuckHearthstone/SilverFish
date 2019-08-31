using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_062 : SimTemplate //* Ball of Spiders
    {
		//Summon three 1/1 Webspinners.
		
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.FP1_011);//Webspinner

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int place = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;

            p.CallKid(kid, place, ownplay, false);
            p.CallKid(kid, place, ownplay);
            p.CallKid(kid, place, ownplay);
		}
	}
}