using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_OG_156 : SimTemplate //* Bilefin Tidehunter
	{
		//Battlecry: Summon a 1/1 Ooze with Taunt.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.OG_156a);
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.callKid(kid, own.zonepos, own.own);
		}
	}
}