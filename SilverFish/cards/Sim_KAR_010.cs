using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_KAR_010 : SimTemplate //Nightbane Templar
    {
        // Battlecry: If you're holding a Dragon, summon two 1/1 Whelps.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.KAR_010a);//Big Bad Wolf

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
                p.callKid(kid, own.zonepos - 1, own.own);
                p.callKid(kid, own.zonepos - 1, own.own);
            }
        }
    }
}