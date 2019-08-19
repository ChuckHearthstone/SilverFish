using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_AT_076 : SimTemplate //* Murloc Knight
	{
		//Inspire: Summon a random Murloc.
		
		CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_050);//Coldlight Oracle 2/2

		public override void onInspire(Playfield p, Minion m, bool own)
        {
			if (m.own == own)
			{
				p.callKid(kid, m.zonepos, m.own);
			}
        }
	}
}