using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_EX1_584 : SimTemplate //* Ancient Mage
	{
        //Battlecry: Give adjacent minions Spell Damage +1.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
                if (m.zonepos == own.zonepos - 1 || m.zonepos == own.zonepos + 1)
                {
                    m.spellpower++;
                    if (own.own)
                    {
                        p.spellpower++;
                    }
                    else
                    {
                        p.enemyspellpower++;
                    }
                }
            }
		}


	}
}