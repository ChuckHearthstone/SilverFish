using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_KAR_702 : SimTemplate //Menagerie Magician
    {
        // Battlecry: Give a random friendly Beast, Dragon, and Murloc +2/+2.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (p.ownMinions != null)
            {
                Minion beastmn = p.ownMinions.Find(beast => beast.handcard.card.race == TAG_RACE.PET);
                if (beastmn != null) p.minionGetBuffed(beastmn, 2, 2);

                Minion dragonmn = p.ownMinions.Find(beast => beast.handcard.card.race == TAG_RACE.DRAGON);
                if (dragonmn != null) p.minionGetBuffed(dragonmn, 2, 2);

                Minion murlocmn = p.ownMinions.Find(beast => beast.handcard.card.race == TAG_RACE.MURLOC);
                if (murlocmn != null) p.minionGetBuffed(murlocmn, 2, 2);
            }
        }
    }
}