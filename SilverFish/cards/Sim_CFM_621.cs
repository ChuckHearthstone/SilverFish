using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CFM_621 : SimTemplate //* Kazakus
	{
		// Battlecry: If your deck has no duplicates, create a custom spell.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (m.own && p.prozis.noDuplicates) p.drawACard(CardDB.cardName.thecoin, m.own, true);
        }
    }
}