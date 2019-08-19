using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_NAX14_02 : SimTemplate //* Frost Breath
	{
		// Hero PowerDestroy all enemy minions that aren't Frozen.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            List<Minion> temp = ownplay ? p.enemyMinions : p.ownMinions;
            int i = 0;
			int tempCount = temp.Count;
            for (; i < tempCount; i++)
            {
				temp[i].extraParam = true;
                if (temp[i].frozen) temp[i].extraParam = false;
                if (temp[i].name == CardDB.cardName.frozenchampion && !temp[i].silenced)
				{
					temp[i].extraParam = false;
					if (i > 0) temp[i-1].extraParam = false;
					if (i + 1 < tempCount) temp[i+1].extraParam = false;
				}
            }
			
            foreach (Minion m in temp)
            {
                if (!m.extraParam) continue;
				m.extraParam = false;
				p.minionGetDestroyed(m);
            }
		}
	}
}