using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_058 : SimTemplate //* sunfuryprotector
	{
        //Battlecry: Give adjacent minions Taunt.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
                if (m.zonepos == own.zonepos - 1 || m.zonepos == own.zonepos + 1)
                {
                    if (!m.taunt)
                    {
                        m.taunt = true;
                        if (m.own) p.anzOwnTaunt++;
                        else p.anzEnemyTaunt++;
                    }
                }
            }
		}
	}
}