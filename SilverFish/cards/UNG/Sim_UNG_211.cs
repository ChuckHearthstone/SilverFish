using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_211 : SimTemplate //* Kalimos, Primal Lord
	{
		//Battlecry: If you played an Elemental last turn, cast an Elemental Invocation.


        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
			if (p.anzOwnElementalsLastTurn > 0 && own.own) p.evaluatePenality -= 12;
        }
    }
}