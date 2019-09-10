using System.Collections.Generic;
using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_GVG_102 : SimTemplate //Tinkertown Technician
    {

        // Battlecry: If you have a Mech, gain +1/+1 and add a Spare Part to your hand.  

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;

            foreach (Minion m in temp)
            {
                if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MECHANICAL)
                {
                    p.minionGetBuffed(own, 1, 1);
                    p.drawACard(CardName.armorplating, own.own, true);
                    return;
                }
            }
        }

    }

}