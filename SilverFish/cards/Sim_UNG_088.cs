using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_088 : SimTemplate //* Tortollan Primalist
	{
		//Battlecry: Discover a spell and cast it with random targets.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
			p.evaluatePenality -= 10;
        }
    }
}