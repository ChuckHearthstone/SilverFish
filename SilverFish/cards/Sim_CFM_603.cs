using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CFM_603 : SimTemplate //* Potion of Madness
	{
		// Gain control of an enemy minion with 2 or less Attack until the end of the turn.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            target.shadowmadnessed = true;
            p.shadowmadnessed++;
            p.minionGetControlled(target, ownplay, true);
        }
    }
}