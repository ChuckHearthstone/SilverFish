using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_028 : SimTemplate //* Open the Waygate
	{
		//Quest: Cast 6 spells that didn't start in your deck. Reward: Time Warp.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
			if (p.playactions.Count < 2) p.evaluatePenality -= 30;
        }
    }
}