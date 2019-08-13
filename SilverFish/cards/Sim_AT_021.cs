using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_021 : SimTemplate //* Tiny Knight of Evil
	{
        //Whenever you discard a card, gain +1/+1.
        //Only on the board
        public override bool onCardDicscard(Playfield p, Handmanager.Handcard hc, Minion own, int num, bool checkBonus)
        {
            if (own == null) return false;
            if (checkBonus) return false;

            p.minionGetBuffed(own, num, num);
            return false;
        }
    }
}