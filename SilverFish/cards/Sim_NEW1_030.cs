using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_NEW1_030 : SimTemplate //deathwing
    {
        //Battlecry: Destroy all other minions and discard your hand.
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.allMinionsGetDestroyed();
            p.discardACard(own.own, true);
		}
	}
}