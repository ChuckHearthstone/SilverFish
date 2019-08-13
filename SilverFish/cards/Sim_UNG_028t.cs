using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_028t : SimTemplate //* Time Warp
	{
		//Take an extra turn.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay)
            {
                if (p.ownMinions.Count > 3) p.evaluatePenality += 100;
                else if (p.ownMinions.Count > 2) p.evaluatePenality += 50;
                else if (p.ownMinions.Count > 1) p.evaluatePenality += 20;
                if (p.nextTurnWin()) p.evaluatePenality += 500;
            }
        }
    }
}