using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CFM_619 : SimTemplate //* Kabal Chemist
	{
		// Battlecry: Add a random Potion to your hand.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            p.drawACard(CardDB.cardName.frostbolt, m.own, true);
        }
    }
}