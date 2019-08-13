using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_EX1_360 : SimTemplate //* Humility
    {
        //Change a minion's Attack to 1.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionSetAngrToX(target, 1);
        }

    }
}
