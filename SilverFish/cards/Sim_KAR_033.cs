using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_KAR_033 : SimTemplate //Book Wyrm
    {
        // Battlecry: If you're holding a Dragon, destroy an enemy minion with 3 or less Attack.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            bool hasdragon = false;
            if (own.own)
            {
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.race == TAG_RACE.DRAGON) hasdragon = true;
                }
            }
            else
            {
                hasdragon = true;
            }
            if (target != null && (hasdragon && target.Angr <= 3))
            {
                p.minionGetDestroyed(target);
            }
        }
    }
}