using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_BRMA07_2_2_TB : SimTemplate //* ME SMASH
	{
		// Hero Power: Destroy a random damaged enemy minion
				
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
			List<Minion> temp = (ownplay) ? new List<Minion>(p.enemyMinions) : new List<Minion>(p.ownMinions);
            temp.Sort((a, b) => a.Angr.CompareTo(b.Angr));
            foreach (Minion m in temp)
            {
				if(m.wounded)
				{
					p.minionGetDestroyed(m);
					break;
				}
            }
		}
	}
}