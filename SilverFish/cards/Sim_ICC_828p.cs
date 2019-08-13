using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_828p: SimTemplate //* Build-a-Beast
    {
        // Hero Power: Craft a custom Zombeast.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardDB.cardName.unknown, ownplay, true);
        }
    }
}