using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_956 : SimTemplate //* Spirit Echo
	{
		//Give your minions "Deathrattle: Return this to your hand."

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            List<Minion> temp = (ownplay) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
                m.returnToHand++;
            }
		}
	}
}