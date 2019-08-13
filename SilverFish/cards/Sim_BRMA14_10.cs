using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_BRMA14_10 : SimTemplate //* Activate!
	{
		// Hero Power: Activate a random Tron.

		CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.BRMA14_5);//3/3toxitron
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int place = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(kid, place, ownplay, false);
        }
	}
}