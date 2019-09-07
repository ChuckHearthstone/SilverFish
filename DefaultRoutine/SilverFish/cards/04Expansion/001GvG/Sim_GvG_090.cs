using System.Collections.Generic;
using HREngine.Bots;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_GVG_090 : SimTemplate //Madder Bomber
    {

        //   Battlecry: Deal 6 damage randomly split between all other characters.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            int anz = 6;
            for (int i = 0; i < anz; i++)
            {
                if (p.ownHero.HealthPoints <= anz)
                {
                    p.minionGetDamageOrHeal(p.ownHero, 1);
                    continue;
                }
                List<Minion> temp = new List<Minion>(p.enemyMinions);
                if (temp.Count == 0)
                {
                    temp.AddRange(p.ownMinions);
                }
                temp.Sort((a, b) => a.HealthPoints.CompareTo(b.HealthPoints));//destroys the weakest

                foreach (Minion m in temp)
                {
                    if (m.entitiyID == own.entitiyID) continue;
                    p.minionGetDamageOrHeal(m, 1);
                    break;
                }
                p.minionGetDamageOrHeal(p.enemyHero, 1);
            }
        }


    }

}