using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_015 : SimTemplate //* Sunkeeper Tarim
	{
		//Taunt. Battlecry: Set all other minions' Attack and Health to 3.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            foreach (Minion m in p.ownMinions)
            {
                if (m.entitiyID == own.entitiyID) continue;
				p.minionSetAngrToX(m, 3);
				p.minionSetLifetoX(m, 3);
            }
            foreach (Minion m in p.enemyMinions)
            {
                if (m.entitiyID == own.entitiyID) continue;
				p.minionSetAngrToX(m, 3);
				p.minionSetLifetoX(m, 3);
            }				
		}
	}
}