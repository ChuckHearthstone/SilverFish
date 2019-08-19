using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CFM_623 : SimTemplate //* Greater Arcane Missiles
	{
		// Shoot three missiles at random enemies that deal 3 damage each.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int times = (ownplay) ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);

            while (times > 0)
            {
                if (ownplay) target = p.getEnemyCharTargetForRandomSingleDamage(3);
                else
                {
                    target = p.searchRandomMinion(p.ownMinions, searchmode.searchHighestAttack); //damage the Highest (pessimistic)
                    if (target == null) target = p.ownHero;
                }
                p.minionGetDamageOrHeal(target, 3);
                times--;
            }
        }
    }
}