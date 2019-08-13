using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CS2_234 : SimTemplate //shadowwordpain
	{
        // Destroy a minion with 3 or less Attack.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (target.Angr <= 3)
            {
                p.minionGetDestroyed(target);
            }
        }
	}
}