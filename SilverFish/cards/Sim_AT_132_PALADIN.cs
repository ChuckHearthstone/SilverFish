using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_AT_132_PALADIN : SimTemplate //* The Silver Hand
	{
		//Hero Power. Summon two 1/1 Recruits.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_101t);//silverhandrecruit

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int place = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(kid, place, ownplay, false);
            p.callKid(kid, place, ownplay);
        }
	}
}