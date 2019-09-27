using System.Collections.Generic;
using SilverFish.Enums;

namespace Chuck.SilverFish.cards._02Classic._09Warrior
{
    class Sim_NEW1_036 : SimTemplate//commanding shout
    {

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            List<Minion> temp = (ownplay) ? p.ownMinions : p.enemyMinions;
            foreach (Minion t in temp)
            {
                t.cantLowerHPbelowONE = true;
            }
            p.drawACard(CardName.unknown, ownplay);
        }

    }
}
