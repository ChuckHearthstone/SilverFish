using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_NAX3_02H : SimTemplate //* Web Wrap
	{
		// Hero Power: Return 2 random enemy minions to your opponent's hand.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            List<Minion> temp = (ownplay) ? new List<Minion>(p.enemyMinions) : new List<Minion>(p.ownMinions);
			
			if (temp.Count > 0)
			{
				if (ownplay) temp.Sort((a, b) => b.Angr.CompareTo(a.Angr));
				else temp.Sort((a, b) => a.Angr.CompareTo(b.Angr));
				
                target = temp[0];
				if (temp.Count > 1)
				{
					Minion target2 = new Minion();
					target2 = temp[1];
					p.minionReturnToHand(target2, !ownplay, 0);
				}
                p.minionReturnToHand(target, !ownplay, 0);
			}
        }
	}
}