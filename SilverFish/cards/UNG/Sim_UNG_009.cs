using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_009 : SimTemplate //* Ravasaur Runt
	{
		//Battlecry: If you control at least 2 other minions, Adapt.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            int num = (own.own) ? p.ownMinions.Count : p.enemyMinions.Count;
			if (num > 1) p.getBestAdapt(own);
        }
    }
}