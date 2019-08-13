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
            List<Minion> list = (m.own) ? p.ownMinions : p.enemyMinions;
            int anz = list.Count;
            p.callKid(kid, m.zonepos, m.own);
            if (anz < 7 && !list[m.zonepos].taunt)
            {
                list[m.zonepos].taunt = true;
                if (m.own) p.anzOwnTaunt++;
                else p.anzEnemyTaunt++;
            }
        }
	}
}