using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_OG_080c : SimTemplate //* Bloodthistle Toxin
	{
        //Return a friendly minion to your hand. It costs (2) less.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionReturnToHand(target, ownplay, -2);
		}
	}
}