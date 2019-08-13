using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_NEW1_008 : SimTemplate //* Ancient of Lore
    {
        //Choose One - Draw a card; or Restore 5 Health.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (choice == 2 || (target != null && p.ownFandralStaghelm > 0 && own.own))
            {
                int heal = (own.own) ? p.getMinionHeal(5) : p.getEnemyMinionHeal(5);
                p.minionGetDamageOrHeal(target, -heal);
            }
            
            if (choice == 1 || (p.ownFandralStaghelm > 0 && own.own))
            {
                p.drawACard(CardDB.cardName.unknown, own.own);
            }
        }
    }
}
