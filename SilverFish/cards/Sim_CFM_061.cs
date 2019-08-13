using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CFM_061 : SimTemplate //* Jinyu Waterspeaker
	{
        // Battlecry: Restore 6 Health. Overload: (1)

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            int heal = (own.own) ? p.getMinionHeal(6) : p.getEnemyMinionHeal(6);

            p.minionGetDamageOrHeal(target, -heal);
            p.changeRecall(own.own, 1);
        }
    }
}