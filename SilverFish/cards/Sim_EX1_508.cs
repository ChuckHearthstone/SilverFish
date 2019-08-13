using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_EX1_508 : SimTemplate//Grimscale Oracle
    {
        //Your other Murlocs have +1 Attack.

        public override void onAuraStarts(Playfield p, Minion own)
        {
            if (own.own) p.anzOwnGrimscaleOracle++;
            else p.anzEnemyGrimscaleOracle++;

            List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
                if (m.handcard.card.race == TAG_RACE.MURLOC && own.entityID != m.entityID) p.minionGetBuffed(m, 1, 0);
            }
        }

        public override void onAuraEnds(Playfield p, Minion m)
        {
            if (m.own) p.anzOwnGrimscaleOracle--;
            else p.anzEnemyGrimscaleOracle--;

            List<Minion> temp = (m.own) ? p.ownMinions : p.enemyMinions;
            foreach (Minion mn in temp)
            {
                if (mn.handcard.card.race == TAG_RACE.MURLOC && mn.entityID != m.entityID) p.minionGetBuffed(m, -1, 0);
            }
        }
    }
}
