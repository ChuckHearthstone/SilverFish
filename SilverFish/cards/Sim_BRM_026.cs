using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_BRM_026 : SimTemplate //* Hungry Dragon
	{
		// Battlecry: Summon a random 1-Cost minion for your opponent.
        		
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_614t); //flameofazzinoth

		public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            int zonepos = (m.own) ? p.enemyMinions.Count : p.ownMinions.Count;
            p.callKid(kid, zonepos, !m.own);
        }
	}
}