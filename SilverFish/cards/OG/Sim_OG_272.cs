using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_OG_272 : SimTemplate //* Twilight Summoner
	{
		//Deathrattle: Summon a 5/5 Faceless Destroyer.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.OG_272t);

        public override void onDeathrattle(Playfield p, Minion m)
        {
			p.callKid(kid, m.zonepos-1, m.own);
        }
	}
}