using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CFM_061 : SimTemplate //* Jinyu Waterspeaker
	{
		// Battlecry: Restore 6 Health. Overload: (1)

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            int heal = (m.own) ? p.getMinionHeal(6) : p.getEnemyMinionHeal(6);

            p.minionGetDamageOrHeal(target, -heal);
            if (m.own) p.ueberladung++;
        }
    }
}