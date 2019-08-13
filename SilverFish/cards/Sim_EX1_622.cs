using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_622 : SimTemplate //shadowworddeath
	{
        // Destroy a minion with an Attack of 5 or more.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (target.Angr >= 5)
            {
                p.minionGetDestroyed(target);
            }
        }

	}
}