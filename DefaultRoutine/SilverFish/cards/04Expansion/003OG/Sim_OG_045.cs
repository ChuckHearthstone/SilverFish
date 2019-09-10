using System.Collections.Generic;
using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._003OG
{
    class Sim_OG_045 : SimTemplate //* Infest
    {
        //Give your minions "Deathrattle: Add a random Beast to your hand."

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            List<Minion> temp = (ownplay) ? p.ownMinions : p.enemyMinions;

            foreach (Minion m in temp)
            {
                m.infest++;
            }
        }
    }
}