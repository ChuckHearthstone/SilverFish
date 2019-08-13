using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_849: SimTemplate //* Embrace Darkness
    {
        // Choose an enemy minion. At the start of your turn, gain control of it.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            target.changeOwnerOnTurnStart = true;
        }
    }
}