using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_841 : SimTemplate //* Blood-Queen Lana'thel
    {
        // Lifesteal. Has +1 Attack for each card you've discarded this game.
        //Only on the board

        public override bool onCardDicscard(Playfield p, Handmanager.Handcard hc, Minion own, int num, bool checkBonus)
        {
            if (own == null) return false;
            if (checkBonus) return false;

            p.minionGetBuffed(own, num, 0);
            return false;
        }
    }
}