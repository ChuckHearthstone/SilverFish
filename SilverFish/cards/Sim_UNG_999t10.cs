using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_999t10 : SimTemplate //* Shrouding Mist
	{
		//Stealth until your next turn.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            target.stealth = true;
            target.conceal = true;
        }
    }
}