using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CFM_064 : SimTemplate //* Blubber Baron
	{
		// Whenever you summon a Battlecry minion while this is in your hand, gain +1/+1.

        //handled

        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Handmanager.Handcard triggerhc)
        {
            if (hc.card.battlecry && hc.card.type == CardDB.cardtype.MOB)
            {
                hc.addattack++;
                hc.addHp++;
            }
        }
    }
}