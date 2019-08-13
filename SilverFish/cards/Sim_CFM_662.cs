using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CFM_662 : SimTemplate //* Dragonfire Potion
	{
		// Deal 5 damage to all minions except Dragons.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(5) : p.getEnemySpellDamageDamage(5);
            foreach (Minion m in p.ownMinions)
            {
                if ((TAG_RACE)m.handcard.card.race != TAG_RACE.DRAGON) p.minionGetDamageOrHeal(m, dmg);
            }
            foreach (Minion m in p.enemyMinions)
            {
                if ((TAG_RACE)m.handcard.card.race != TAG_RACE.DRAGON) p.minionGetDamageOrHeal(m, dmg);
            }
        }
    }
}