using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_KAR_004 : SimTemplate //* Cat Trick
	{
		//Secret: After your opponent casts a spell, summon a 4/2 Panther with Stealth.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.KAR_004a);//Panther - Cat in a Hat

        public override void onSecretPlay(Playfield p, bool ownplay, int number)
        {
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
			p.callKid(kid, pos, ownplay, false);
        }
    }
}