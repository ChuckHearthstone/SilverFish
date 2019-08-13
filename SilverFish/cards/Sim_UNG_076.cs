using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_076 : SimTemplate //* Eggnapper
	{
		//Deathrattle: Summon two 1/1 Raptors.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.UNG_076t1); //1/1 Raptor
        
        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.callKid(kid, m.zonepos-1, m.own);
            p.callKid(kid, m.zonepos-1, m.own);
        }
	}
}