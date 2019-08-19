using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_827t : SimTemplate //* Shadow Reflection
    {
        //Each time you play a card, transform this into a copy of it.

        //handled

        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Handmanager.Handcard triggerhc)
        {
            triggerhc.setHCtoHC(hc);
        }
    }
}