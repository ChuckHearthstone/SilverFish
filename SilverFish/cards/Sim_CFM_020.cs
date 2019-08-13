using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CFM_020 : SimTemplate //* Raza the Chained
	{
		// Battlecry: If your deck has no duplicates, your Hero Power costs (0) this game.
				
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own && p.prozis.noDuplicates) p.ownHeroAblility.manacost = 0;
        }
	}
}