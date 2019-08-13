using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_AT_036 : SimTemplate //* Anub'arak
	{
		//Deathrattle: Return this to your hand and summon a 4/4 Nerubian.
		
		CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.FP1_007t);//Nerubian

        public override void onDeathrattle(Playfield p, Minion m)
        {
			p.minionReturnToHand(m, m.own, 0);
            p.callKid(kid, m.zonepos - 1, m.own);		
        }
	}
}