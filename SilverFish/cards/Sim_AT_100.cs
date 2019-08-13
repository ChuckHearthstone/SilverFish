using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_AT_100 : SimTemplate //* Silver Hand Regent
	{
		//Inspire: Summon a 1/1 Silver Hand Recruit.
		
		CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_101t);//silverhandrecruit
		
		public override void onInspire(Playfield p, Minion m, bool own)
        {
            if (m.own == own) p.callKid(kid, m.zonepos, own);
        }
	}
}