using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_AT_018 : SimTemplate //* Confessor Paletress
	{
		//Inspire: Summon a random Legendary minion.

		CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_014);//King Mukla 5/5
		
		public override void onInspire(Playfield p, Minion m, bool own)
        {
			if (m.own == own)
			{				
				p.callKid(kid, m.zonepos, m.own);
			}
        }
	}
}