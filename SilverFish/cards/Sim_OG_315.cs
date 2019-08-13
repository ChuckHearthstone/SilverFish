using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_OG_315 : SimTemplate //* Bloodsail Cultist
    {
        //Battlecry: If you control a Pirate, give your weapon +1/+1.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
                if (m.entitiyID == own.entitiyID) continue;
                if ((TAG_RACE)m.handcard.card.race == TAG_RACE.PIRATE)
                {
                    if (own.own)
                    {
                        if (p.ownWeapon.Durability > 0)
                        {
                            p.ownWeapon.Durability++;
                            p.ownWeapon.Angr++;
                            p.minionGetBuffed(p.ownHero, 1, 0);
                        }
                    }
                    else
                    {
                        if (p.enemyWeapon.Durability > 0)
                        {
                            p.enemyWeapon.Durability++;
                            p.enemyWeapon.Angr++;
                            p.minionGetBuffed(p.enemyHero, 1, 0);
                        }
                    }
                    break;
                }
            }
        }
    }
}