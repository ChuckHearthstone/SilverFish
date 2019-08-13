using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_507 : SimTemplate //murlocwarleader
	{
        // Your other Murlocs have +2/+1.

        public override void onAuraStarts(Playfield p, Minion own)
        {
            if (own.own) p.anzOwnMurlocWarleader++;
            else p.anzEnemyMurlocWarleader++;

            List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
                if (m.handcard.card.race == TAG_RACE.MURLOC && own.entityID != m.entityID) p.minionGetBuffed(m, 2, 1);
            }
        }

        public override void onAuraEnds(Playfield p, Minion m)
        {
            if (m.own) p.anzOwnMurlocWarleader--;
            else p.anzEnemyMurlocWarleader--;

            List<Minion> temp = (m.own) ? p.ownMinions : p.enemyMinions;
            foreach (Minion mn in temp)
            {
                if (mn.handcard.card.race == TAG_RACE.MURLOC && mn.entityID != m.entityID) p.minionGetBuffed(m, -2, -1);
            }
        }
        
	}
}