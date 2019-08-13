using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_KAR_062 : SimTemplate //Netherspite Historian
    {
        // Battlecry: If you're holding a Dragon, Discover a Dragon.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (p.ownMinions.Find(m => m.handcard.card.race == TAG_RACE.DRAGON) != null)
            {
                p.drawACard(CardDB.cardName.unknown, own.own);
            }
        }
    }
}