using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CFM_693 : SimTemplate //* Gadgetzan Ferryman
	{
		// Combo: Return a friendly minion to your hand.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (p.cardsPlayedThisTurn > 0 && target != null) p.minionReturnToHand(target, target.own, 0);
        }
    }
}