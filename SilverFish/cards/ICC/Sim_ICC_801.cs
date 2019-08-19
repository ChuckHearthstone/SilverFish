using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_801: SimTemplate //* Howling Commander
    {
        // Battlecry: Draw a Divine Shield minion from your deck.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            p.drawACard(CardDB.cardName.unknown, m.own);
        }
    }
}