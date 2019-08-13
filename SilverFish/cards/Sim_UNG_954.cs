using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_954 : SimTemplate //* The Last Kaleidosaur
	{
		//Quest: Cast 6 spells on your minions. Reward: Galvadon.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (p.playactions.Count < 2) p.evaluatePenality -= 30;
        }
    }
}