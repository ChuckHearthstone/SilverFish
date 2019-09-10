using System.Collections.Generic;
using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._003OG
{
	class Sim_OG_116 : SimTemplate //* Spreading Madness
	{
		//Deal 9 damage randomly split among ALL characters.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            List<Minion> temp = new List<Minion>(p.enemyMinions);
            temp.AddRange(p.ownMinions);
            temp.Sort((a, b) => a.HealthPoints.CompareTo(b.HealthPoints)); //destroys the weakest first
            int times = (ownplay) ? p.getSpellDamageDamage(9) : p.getEnemySpellDamageDamage(9);

            for (int i = 0; i < times; i++)
            {
                for (int j = 0; j < temp.Count; j++)
                {
                    p.minionGetDamageOrHeal(temp[j], 1);
                    i++;
                    if (i >= times) break;
                }
                p.minionGetDamageOrHeal(p.enemyHero, 1);
                p.minionGetDamageOrHeal(p.ownHero, 1);
                i++;
            }
        }
    }
}