using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_OG_207 : SimTemplate //* Faceless Summoner
	{
		//Battlecry: Summon a random 3-Cost minion.
		
		CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_106); //Light's Champion
				
		public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            int pos = (m.own) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(kid, pos, m.own, true);
        }
	}
}