using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_067t1 : SimTemplate //* Crystal Core
	{
		//For the rest of the game, your minions are 5/5.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay)
            {
                p.ownCrystalCore = 5;
                foreach (Minion m in p.ownMinions)
                {
                    p.minionSetAngrToX(m, 5);
                    p.minionSetLifetoX(m, 5);
                }

                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    hc.addattack = 5 - hc.card.Attack;
                    hc.addHp += 5 - hc.card.Health;
                }
            }
        }
    }
}