using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_BRMA06_2H_TB : SimTemplate //* The Majordomo
	{
		// Hero Power: Summon a 3/3 Flamewaker Acolyte.
		
		CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.BRMA06_4H);//3/3Flamewaker Acolyte
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int place = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(kid, place, ownplay, false);
        }
	}
}