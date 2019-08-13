using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_KAR_077 : SimTemplate //* Silvermoon Portal
	{
		//Give a minion +2/+2. Summon a random 2-Cost minion.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionGetBuffed(target, 2, 2);
			
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(p.getRandomCardForManaMinion(2), pos, ownplay);
		}
	}
}