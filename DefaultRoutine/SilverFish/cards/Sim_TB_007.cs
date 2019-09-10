using System;
using System.Collections.Generic;
using System.Text;

namespace Chuck.SilverFish
{
	class Sim_TB_007 : SimTemplate //* Deviate Banana
	{
		// Swap a minion's Attack and Health.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionSwapAngrAndHP(target);
        }
    }
}