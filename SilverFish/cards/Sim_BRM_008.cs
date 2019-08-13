using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_BRM_008 : SimTemplate //* Dark Iron Skulker
	{
		//	Battlecry: Deal 2 damage to all undamaged enemy minions.
	
        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
			List<Minion> temp = (m.own) ? p.enemyMinions : p.ownMinions;
			
            foreach (Minion mnn in temp)
            {
                if (!mnn.wounded)
                {
					p.minionGetDamageOrHeal(mnn, 2);
                }
            }
        }
	}
}