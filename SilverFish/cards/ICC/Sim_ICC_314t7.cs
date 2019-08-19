using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_314t7 : SimTemplate //* Anti-Magic Shell
    {
        // Give your minions +2/+2 and "Can't be targeted by spells or Hero Powers."

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.allMinionOfASideGetBuffed(ownplay, 2, 2);

            List<Minion> temp = (ownplay) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp) m.cantBeTargetedBySpellsOrHeroPowers = true;
        }
    }
}