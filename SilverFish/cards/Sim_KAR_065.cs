using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_KAR_065 : SimTemplate //Menagerie Warden
    {
        // Battlecry: Choose a friendly Beast. Summon a copy of it.
        
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null && target.handcard.card.race == TAG_RACE.PET)
            {
                p.callKid(target.handcard.card, target.zonepos, own.own);
                List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;
                foreach (Minion mnn in temp)
                {
                    if (mnn.name == target.name && target.entityID != mnn.entityID)
                    {
                        mnn.setMinionTominion(target);
                        break;
                    }
                }
            }

        }
    }
}