using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_204 : SimTemplate //* Professor Putricide
    {
        // After you play a Secret, put another random Hunter secret into play.

        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool ownplay, Minion m)
        {
            if (hc.card.Secret) p.evaluatePenality -= 9;
        }

    }
}