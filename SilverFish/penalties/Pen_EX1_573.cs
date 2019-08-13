using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_EX1_573 : PenTemplate //cenarius
    {
        //Choose One - Give your minions +2/2; or summon two 2/2 treants with taunt

        public override float getPlayPenalty(Playfield p, Handmanager.Handcard hc, Minion target, int choice, bool isLethal)
        {
            if (choice == 1)
            {
                if (p.ownMinions.Count == 0) return 500;
                else if (p.ownMinions.Count < 3) return 2 * p.ownMinions.Count;
            }
            if (choice == 2)
            {
                if (p.ownMinions.Count > 5) return 500;
            }
            return 0;
        }
    }
}
