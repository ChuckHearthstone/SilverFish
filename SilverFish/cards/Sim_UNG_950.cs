using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_950 : SimTemplate //* Vinecleaver
	{
		//After your hero attacks, summon two 1/1 Silver Hand Recruits.

        CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_101t);
        
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(weapon, ownplay);
        }
    }
}