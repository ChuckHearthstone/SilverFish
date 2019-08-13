using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_OG_229 : SimTemplate //* Ragnaros, Lightlord
    {
        //At the end of your turn, restore 8 health to a damaged friendly character.

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                int heal = (turnEndOfOwner) ? p.getMinionHeal(8) : p.getEnemyMinionHeal(8);
                List<Minion> temp = (turnEndOfOwner) ? p.ownMinions : p.enemyMinions;
                if (temp.Count >= 1)
                {
                    bool healed = false;
                    foreach (Minion m in temp)
                    {
                        if (m.wounded)
                        {
                            p.minionGetDamageOrHeal(m, -heal);
                            healed = true;
                            break;
                        }
                    }

                    if (!healed)
                    {
                        p.minionGetDamageOrHeal(turnEndOfOwner ? p.ownHero : p.enemyHero, -heal);
                    }
                }
                else
                {
                    p.minionGetDamageOrHeal(turnEndOfOwner ? p.ownHero : p.enemyHero, -heal);
                }
            }
        }
    }
}