using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_954t1 : SimTemplate //* Galvadon
	{
		//Battlecry: Adapt 5 times.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.minionGetBuffed(own, 6, 0);
            p.minionGetBuffed(own, 0, 3);
            own.taunt = true;
            own.divineshild = true;
        }
    }
}