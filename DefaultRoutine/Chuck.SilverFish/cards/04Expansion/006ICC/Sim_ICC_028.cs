using System.Collections.Generic;
using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_028: SimTemplate //* Sunborne Val'kyr
    {
        // Battlecry: Give adjacent minions +2 Health.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
                if (m.zonepos == own.zonepos - 1 || m.zonepos == own.zonepos + 1)
                {
                    p.minionGetBuffed(m, 0, 2);
                }
            }
        }
    }
}