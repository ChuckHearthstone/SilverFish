using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_011 : SimTemplate //Shrinkmeister
    {
        // Battlecry: Give a minion -2 Attack this turn.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null)
            {
                p.minionGetTempBuff(target, -2, 0);
            }
        }
    }
}