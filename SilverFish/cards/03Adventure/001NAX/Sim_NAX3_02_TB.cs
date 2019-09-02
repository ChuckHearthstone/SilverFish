using System.Collections.Generic;
using HREngine.Bots;

namespace SilverFish.cards._03Adventure._001NAX
{
	class Sim_NAX3_02_TB : SimTemplate //* Web Wrap
	{
		// Hero Power: Return a random enemy minion to your opponent's hand.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            List<Minion> temp = (ownplay) ? new List<Minion>(p.enemyMinions) : new List<Minion>(p.ownMinions);
			
			if (temp.Count > 0)
			{
				if (ownplay) temp.Sort((a, b) => b.Attack.CompareTo(a.Attack));
				else temp.Sort((a, b) => a.Attack.CompareTo(b.Attack));
				
                target = temp[0];
                if (ownplay && temp.Count >= 2 && !target.taunt && temp[1].taunt) target = temp[1];
                p.minionReturnToHand(target, !ownplay, 0);
			}
        }
	}
}