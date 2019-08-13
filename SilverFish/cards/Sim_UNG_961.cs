using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_961 : SimTemplate //* Adaptation
	{
		//Adapt a friendly minion.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.evaluatePenality -= 15;
		}
	}
}