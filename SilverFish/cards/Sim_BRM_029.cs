using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_BRM_029 : SimTemplate //Rend Blackhand
    {
        // If you're holding a Dragon, destroy a Legendary minion.

        //todo sepefeets - move dragon check to shared function in carddb!
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

            if (hasdragon)
            {
                if (target != null && target.handcard.card.rarity >= 5) //requires legendary target
                {
                    p.minionGetDestroyed(target);
                }
            }
        }

    }
}