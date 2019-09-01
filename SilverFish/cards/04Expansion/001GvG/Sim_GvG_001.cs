using System.Collections.Generic;
using HREngine.Bots;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_GVG_001 : SimTemplate //Flamecannon
    {

        //    Deal $4 damage to a random enemy minion.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            // optimistic

            List<Minion> temp = (ownplay) ? p.enemyMinions : p.ownMinions;
            int times = (ownplay) ? p.getSpellDamageDamage(4) : p.getEnemySpellDamageDamage(4);

            if (temp.Count >= 1)
            {
                //search Minion with lowest hp
                Minion enemy = temp[0];
                int minhp = 10000;
                foreach (Minion m in temp)
                {
                    if (m.HealthPoints >= times + 1 && minhp > m.HealthPoints)
                    {
                        enemy = m;
                        minhp = m.HealthPoints;
                    }
                }

                p.minionGetDamageOrHeal(enemy, times);

            }
        }

    }

}