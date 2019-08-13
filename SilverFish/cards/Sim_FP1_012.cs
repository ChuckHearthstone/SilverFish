using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_FP1_012 : SimTemplate //* Sludge Belcher
	{
		//Taunt. Deathrattle: Summon a 1/2 Slime with Taunt.
		
        CardDB.Card c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.FP1_012t);
		
        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.callKid(c, m.zonepos - 1, m.own);
        }
	}
}