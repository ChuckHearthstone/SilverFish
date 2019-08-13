using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CFM_852 : SimTemplate //* Lotus Agents
	{
		// Battlecry: Discover a Druid, Rogue or Shaman card.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            p.drawACard(CardDB.cardName.shieldbearer, m.own, true);
        }
    }
}