using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_081: SimTemplate //* Drakkari Defender
    {
        // Taunt Overload: (3)

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own) p.ueberladung += 3;
        }
    }
}