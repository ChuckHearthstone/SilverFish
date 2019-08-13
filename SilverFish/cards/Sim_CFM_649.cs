using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CFM_649 : SimTemplate //* Kabal Courier
	{
		// Battlecry: Discover a Mage, Priest or Warlock card.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            p.drawACard(CardDB.cardName.shieldbearer, m.own, true);
        }
    }
}