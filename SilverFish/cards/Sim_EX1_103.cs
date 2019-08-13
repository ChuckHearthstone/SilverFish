using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_EX1_103 : SimTemplate//Coldlight Seer
    {
        // Battlecry: Give your other Murlocs +2 Health.
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
                if (m.handcard.card.race == TAG_RACE.MURLOC && own.entityID != m.entityID) p.minionGetBuffed(m, 0, 2);
            }
        }
    }
}
