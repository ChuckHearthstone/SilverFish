using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_915 : SimTemplate //* Crackling Razormaw
	{
		//Battlecry: Adapt a friendly Beast.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
			if (target != null) p.getBestAdapt(own);
        }
    }
}