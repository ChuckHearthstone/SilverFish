using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_OG_337 : SimTemplate //* Cyclopian Horror
	{
		//Taunt. Battlecry: Gain +1 Health for each enemy minion.
		
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            int gain = (own.own) ? p.enemyMinions.Count : p.ownMinions.Count;
			if (gain > 0) p.minionGetBuffed(own, 0, gain);
        }
    }
}