using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_002 : SimTemplate //* Volcanosaur
	{
		//Battlecry: Adapt, then Adapt.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
			p.getBestAdapt(own);
			p.getBestAdapt(own);
        }
    }
}