using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_830 : SimTemplate //* Cruel Dinomancer
	{
		//Deathrattle: Summon a random minion you discarded this game.

        public override void onDeathrattle(Playfield p, Minion m)
        {
			p.callKid(CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.KAR_205), m.zonepos-1, m.own); //Silverware Golem.
        }
	}
}