using System.Collections.Generic;
using HREngine.Bots;

namespace SilverFish.cards._01Basic
{
	class Sim_CS2_114 : SimTemplate //cleave
	{

//    fügt zwei zufälligen feindlichen dienern $2 schaden zu.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            //TODO delete new list
            int damage = (ownplay) ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
            List<Minion> temp2 = (ownplay) ? new List<Minion>(p.enemyMinions) : new List<Minion>(p.ownMinions) ;
            temp2.Sort((a, b) => a.HealthPoints.CompareTo(b.HealthPoints));
            int i = 0;
            foreach (Minion enemy in temp2)
            {
                p.minionGetDamageOrHeal(enemy, damage);
                i++;
                if (i == 2) break;
            }


		}

	}
}