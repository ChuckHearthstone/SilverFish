using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_281: SimTemplate //* Forge of Souls
    {
        // Draw 2 weapons from your deck.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardDB.cardName.fierywaraxe, ownplay);
            p.drawACard(CardDB.cardName.unknown, ownplay);
        }
    }
}