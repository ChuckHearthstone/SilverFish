using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_AT_085 : SimTemplate //* Maiden of the Lake
	{
		//Your Hero Power costs (1).
		
        public override void onAuraStarts(Playfield p, Minion own)
		{
            if (own.own)
            {
				if (p.ownHeroAblility.manacost > 1) p.ownHeroAblility.manacost--;
            }
            else
            {				
				if (p.enemyHeroAblility.manacost > 1) p.enemyHeroAblility.manacost--;
            }
		}

        public override void onAuraEnds(Playfield p, Minion own)
        {
			bool another = false;
            if (own.own)
            {
                foreach (Minion m in p.ownMinions)
                {
					if (m.name == CardDB.cardName.maidenofthelake && !m.silenced && own.entitiyID != m.entitiyID) another = true;
                }
				if (!another) p.ownHeroAblility.manacost++;
            }
            else
            {
                foreach (Minion m in p.enemyMinions)
                {
					if (m.name == CardDB.cardName.maidenofthelake && !m.silenced && own.entitiyID != m.entitiyID) another = true;
                }
				if (!another) p.enemyHeroAblility.manacost++;
            }
        }
	}
}