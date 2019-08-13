using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_OG_023 : SimTemplate //* Primal Fusion
    {
        //Give a minion +1/+1 for each of your Totems.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int gain = 0;
            List<Minion> temp = (ownplay) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
                if ((TAG_RACE)m.handcard.card.race == TAG_RACE.TOTEM) gain++;
            }
            if (gain > 0) p.minionGetBuffed(target, gain, gain);
        }
    }
}