using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_LOOT_357 : SimTemplate //* Marin the Fox
	{
		// Battlecry: Summon a 0/8 Treasure Chest for your opponent. (Break it for awesome loot!)
        		
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.LOOT_357l); //Treasure Chest

		public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            int pos = (m.own) ? p.enemyMinions.Count : p.ownMinions.Count;
            p.callKid(kid, pos, !m.own);
			
			if (pos < 7)
			{
				if (m.own) p.evaluatePenality -= 40;
				else p.evaluatePenality += 40;
			}
        }
	}
}