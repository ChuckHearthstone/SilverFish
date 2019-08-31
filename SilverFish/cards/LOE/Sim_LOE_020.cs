using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_LOE_020 : SimTemplate //* Desert Camel
	{
        //Battlecry: Put a 1-Cost minion from each deck into the battlefield.
		
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.BRM_004); //Twilight Whelp

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.CallKid(kid, p.ownMinions.Count, true);
			p.CallKid(kid, p.enemyMinions.Count, false);
		}
	}
}