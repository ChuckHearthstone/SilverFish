using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_KAR_095 : SimTemplate //Zoobot
    {
        // Battlecry: Give a random friendly Beast, Dragon, and Murloc +1/+1.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (p.ownMinions != null)
            {
                Minion beastmn = p.ownMinions.Find(beast => beast.handcard.card.race == TAG_RACE.PET);
                if (beastmn != null) p.minionGetBuffed(beastmn, 1, 1);

                Minion dragonmn = p.ownMinions.Find(beast => beast.handcard.card.race == TAG_RACE.DRAGON);
                if (dragonmn != null) p.minionGetBuffed(dragonmn, 1, 1);

                Minion murlocmn = p.ownMinions.Find(beast => beast.handcard.card.race == TAG_RACE.MURLOC);
                if (murlocmn != null) p.minionGetBuffed(murlocmn, 1, 1);
            }
        }
    }
}