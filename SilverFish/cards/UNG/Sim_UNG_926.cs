using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_926 : SimTemplate //* Cornered Sentry
	{
		//Taunt. Battlecry: Summon three 1/1 Raptors for your opponent.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.UNG_076t1); //1/1 Raptor

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            int pos = (own.own) ? p.enemyMinions.Count : p.ownMinions.Count;
            p.callKid(kid, pos, !own.own);
            p.callKid(kid, pos, !own.own);
            p.callKid(kid, pos, !own.own);
		}
	}
}