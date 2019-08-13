using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_047t : SimTemplate //* Fatespinner on board
    {
        // Choose a Deathrattle (Secretly) - Deal 3 damage to all minions; or Give them +2/+2.
        
        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (m.own)
            {
                if (m.hChoice == 1)
                {
                    p.allMinionOfASideGetBuffed(true, 2, 2);
                    p.allMinionOfASideGetBuffed(false, 2, 2);
                }
                else if (m.hChoice == 2) p.allMinionsGetDamage(3);
            }
            else if (!m.silenced)
            {
                if (p.prozis.enemyMinions.Count > p.prozis.ownMinions.Count)
                {
                    p.allMinionOfASideGetBuffed(false, 2, 2);
                }
                else p.allMinionsGetDamage(3);
            }
        }
    }
}