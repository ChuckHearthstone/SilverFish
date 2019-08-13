using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_BRM_034 : SimTemplate //Blackwing Corruptor
    {
        // If you're holding a Dragon, deal 3 damage.

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
                if (target != null) //requires target
                {
                    int dmg = 3;
                    p.minionGetDamageOrHeal(target, dmg);
                }
            }
        }

    }
}